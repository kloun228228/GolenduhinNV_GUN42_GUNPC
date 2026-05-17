using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace DefaultNamespace
{
    public class PositionSaver : MonoBehaviour
    {
        [System.Serializable] // ПУНКТ: Сделали структуру сериализуемой
        public struct Data
        {
            public Vector3 Position;
            public float Time;
        }

        [ReadOnly] // ПУНКТ: Сделали поле нередактируемым
        [Tooltip("Для заполнения этого поля воспользуйтесь контекстным меню в инспекторе и командой 'Create File'")] // ПУНКТ: Добавили подсказку
        [SerializeField] private TextAsset _json;

        [field: SerializeField, HideInInspector] // ПУНКТ: Сделали автосвойство сериализуемым и скрытым
        public List<Data> Records { get; private set; }

        private void Awake()
        {
            // //todo comment: Что будет, если в теле этого условия не сделать выход из метода?
            // Ответ: Программа попытается прочитать _json.text. Так как _json равен null, возникнет ошибка NullReferenceException.
            if (_json == null)
            {
                gameObject.SetActive(false);
                Debug.LogError("Please, create TextAsset and add in field _json");
                return;
            }

            JsonUtility.FromJsonOverwrite(_json.text, this);

            // //todo comment: Для чего нужна эта проверка (что она позволяет избежать)?
            // Ответ: Она гарантирует, что список Records будет создан в памяти. Это позволяет избежать ошибок при попытке добавить в него данные позже.
            if (Records == null)
                Records = new List<Data>(10);
        }

        private void OnDrawGizmos()
        {
            // //todo comment: Зачем нужны эти проверки (что они позволяют избежать)?
            // Ответ: Чтобы не пытаться рисовать линии, если данных еще нет. Это предотвращает ошибки "IndexOutOfRangeException" в консоли.
            if (Records == null || Records.Count == 0) return;

            var data = Records;
            var prev = data[0].Position;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(prev, 0.3f);

            // //todo comment: Почему итерация начинается не с нулевого элемента?
            // Ответ: Потому что для рисования линии нужны две точки. Мы соединяем текущую точку (i) с предыдущей (i-1).
            for (int i = 1; i < data.Count; i++)
            {
                var curr = data[i].Position;
                Gizmos.DrawWireSphere(curr, 0.3f);
                Gizmos.DrawLine(prev, curr);
                prev = curr;
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Create File")]
        private void CreateFile()
        {
            // //todo comment: Что происходит в этой строке?
            // Ответ: В этой строке на жестком диске создается пустой файл "Path.txt" по указанному пути.
            string pathFile = Path.Combine(Application.dataPath, "Path.txt");
            var stream = File.Create(pathFile);

            // //todo comment: Подумайте для чего нужна эта строка? (а потом проверьте догадку, закомментировав её)
            // Ответ: Она закрывает поток и освобождает файл. Если её не вызвать, файл будет "занят" и Unity не сможет его использовать.
            stream.Dispose();

            UnityEditor.AssetDatabase.Refresh();

            // Ищем ассет по типу TextAsset
            var guids = UnityEditor.AssetDatabase.FindAssets("t:TextAsset");
            foreach (var guid in guids)
            {
                var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>(path);

                // //todo comment: Для чего нужны эти проверки?
                // Ответ: Чтобы среди всех текстовых файлов проекта найти именно наш новый файл с именем "Path".
                if (asset != null && asset.name == "Path")
                {
                    _json = asset;
                    UnityEditor.EditorUtility.SetDirty(this);
                    UnityEditor.AssetDatabase.SaveAssets();
                    UnityEditor.AssetDatabase.Refresh();

                    // //todo comment: Почему мы здесь выходим, а на предыдущих итерируемся?
                    // Ответ: Потому что цель достигнута — файл найден и назначен. Дальнейший поиск не имеет смысла.
                    return;
                }
            }
        }

        private void OnDestroy()
        {
            // ПУНКТ: Реализация метода OnDestroy для сохранения данных
            if (_json != null)
            {
                string path = UnityEditor.AssetDatabase.GetAssetPath(_json);
                string jsonContent = JsonUtility.ToJson(this, true);
                File.WriteAllText(path, jsonContent);
                UnityEditor.AssetDatabase.Refresh();
            }
        }
#endif
    }
}
