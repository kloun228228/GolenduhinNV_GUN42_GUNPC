using System;
using UnityEngine;

namespace DefaultNamespace
{
	[RequireComponent(typeof(PositionSaver))]
	public class ReplayMover : MonoBehaviour
	{
		private PositionSaver _save;

		private int _index;
		private PositionSaver.Data _prev;
		private float _duration;

		private void Start()
		{
            ////todo comment: зачем нужны эти проверки?
            //// Чтобы убедиться, что компонент PositionSaver найден и в нём есть записанные точки. Без этого код выдаст ошибку.
            if (!TryGetComponent(out _save) || _save.Records.Count == 0)
			{
				Debug.LogError("Records incorrect value", this);
                //todo comment: Для чего выключается этот компонент?
                //Чтобы остановить выполнение метода Update и сэкономить ресурсы, если данных для воспроизведения нет.
                enabled = false;
			}
		}

		private void Update()
		{
			var curr = _save.Records[_index];
			//todo comment: Что проверяет это условие (с какой целью)? 
			if (Time.time > curr.Time)
			{
				_prev = curr;
				_index++;
                //todo comment: Для чего нужна эта проверка?
                //Чтобы избежать ошибки при делении на ноль, если время между двумя точками равно нулю.
                if (_index >= _save.Records.Count)
				{
					enabled = false;
					Debug.Log($"<b>{name}</b> finished", this);
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif
                }
			}
            //todo comment: Для чего производятся эти вычисления (как в дальнейшем они применяются)?
            //Вычисляется процент прогресса времени между двумя точками (от 0 до 1), чтобы понять, в какой части пути сейчас должен находиться объект.
            var delta = (Time.time - _prev.Time) / (curr.Time - _prev.Time);
			//todo comment: Зачем нужна эта проверка?
			if (float.IsNaN(delta)) delta = 0f;
            //todo comment: Опишите, что происходит в этой строчке так подробно, насколько это возможно
            //Функция плавно перемещает объект из точки _prev в точку curr на расстояние, равное коэффициенту delta.
            transform.position = Vector3.Lerp(_prev.Position, curr.Position, delta);
		}
	}
}