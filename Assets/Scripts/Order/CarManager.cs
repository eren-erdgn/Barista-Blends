using System;
using System.Collections;
using DG.Tweening;
using EventSystem;
using PlaceHolder;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Order
{
    public class CarManager : MonoBehaviour
    {
        
        [SerializeField] private int scoreAmount = 10;
        private bool _isTimerStarted;
        [SerializeField] private GameObject[] carPrefabs;
        [SerializeField] private Transform carInstantiationPoint;
        [SerializeField] private Transform carServePoint;
        [SerializeField] private Transform carEndPoint;
        private GameObject _instantiatedCar;
        [SerializeField]private ServePoint servePoint;
        private float _timer = 60f;
        private Car _car;
        
        private void Start()
        {
            InstantiateCar();
            GoToServePoint();
        }
        private void FixedUpdate()
        {
            if (!_isTimerStarted) return;
            _timer -= Time.deltaTime;

            Events.OnTimerChange.Invoke(_timer);
    
            if (_timer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                return;
            }

            if (!servePoint.IsRightDrinkServed) return;

            _timer = 60f;
            _isTimerStarted = false;
            servePoint.IsRightDrinkServed = false;
            Events.OnTimerChange.Invoke(_timer);
            Events.OnOrderChange.Invoke("");
            Events.OnScoreChange.Invoke(scoreAmount);
            GoToEndPoint();
        }
        private void InstantiateCar()
        {
            var randomCar = Random.Range(0, carPrefabs.Length);
            _instantiatedCar = Instantiate(carPrefabs[randomCar], carInstantiationPoint.position, Quaternion.Euler(0, 90, 0));
            _car = _instantiatedCar.GetComponent<Car>();
        }
        private void GoToServePoint()
        {
            if (_instantiatedCar != null)
            {
                _instantiatedCar.transform.DOMove(carServePoint.position, 5f).OnComplete(() =>
                {
                    _instantiatedCar.transform.SetParent(carServePoint);
                    _car.ChooseRandomDrink();
                    _isTimerStarted = true;
                });
            }
        }

        
        private void GoToEndPoint()
        {
            if (_instantiatedCar != null)
            {
                _instantiatedCar.transform.DOMove(carEndPoint.position, 5f).OnComplete(() =>
                {
                    DestroyAndInstantiateNewCar();
                });
            }
        }
        private void DestroyAndInstantiateNewCar()
        {
            Destroy(_instantiatedCar);
            _instantiatedCar = null;
            _car = null;
            InstantiateCar();
            GoToServePoint();
        }
    }
}
