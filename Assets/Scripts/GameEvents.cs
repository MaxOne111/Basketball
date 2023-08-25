using System;
using UnityEngine;


    public static class GameEvents
    {
        public static Action _Cast;
        public static Action _Hit;
        public static Action _Miss;
        public static Action _Next_Round;
        public static Action _Answer;

        public static void Cast()
        {
            _Cast?.Invoke();
        }

        public static void Hit()
        {
            _Hit?.Invoke();
        }

        public static void NextRound()
        {
            _Next_Round?.Invoke();
        }

        public static void Miss()
        {
            _Miss?.Invoke();
        }

        public static void Answer()
        {
            _Answer?.Invoke();
        }
    }
