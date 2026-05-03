using UnityEngine;

namespace DefaultNamespace
{
	
	[RequireComponent(typeof(PositionSaver))]
	public class EditorMover : MonoBehaviour
	{
		private PositionSaver _save;
		private float _currentDelay;

        //todo comment: Что произойдёт, если _delay > _duration?
        //Запись завершится раньше, чем сработает первый интервал таймера.
        [SerializeField, Range(0.2f, 1.0f)]
		private float _delay = 0.5f;
		[SerializeField, Min(0.2f)]
		private float _duration = 5f;

		private void Start()
		{
           
                //todo comment: Почему этот поиск производится здесь, а не в начале метода Update?
                //В Start она выполняется один раз, а в Update она бы выполнялась 60–100 раз в секунду, что сильно ударило бы по производительности
                _save = GetComponent<PositionSaver>();
            if (_duration < _delay * 5)
			{

			}
                _save.Records.Clear();
		}

		private void Update()
		{
			_duration -= Time.deltaTime;
			if (_duration <= 0f)
			{
				enabled = false;
				Debug.Log($"<b>{name}</b> finished", this);
				return;
			}

            //todo comment: Почему не написать (_delay -= Time.deltaTime;) по аналогии с полем _duration?
            //Если мы будем вычитать из неё время, каждый следующий интервал записи будет становиться короче предыдущего. Для отсчета нам нужна отдельная переменная-таймер (
            _currentDelay -= Time.deltaTime;
			if (_currentDelay <= 0f)
			{
				_currentDelay = _delay;
				_save.Records.Add(new PositionSaver.Data
				{
					Position = transform.position,
                    //todo comment: Для чего сохраняется значение игрового времени?
                    //Чтобы в ReplayMover мы могли воспроизвести движение не просто по очереди, а с той же скоростью и таймингами, с которыми оно записывалось.
                    Time = Time.time,
				});
			}
		}
	}
}