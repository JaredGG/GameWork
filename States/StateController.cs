﻿using System.Collections.Generic;
using GameWork.Interfaces;
using GameWork.States.Interfaces;

namespace GameWork.States
{
	public class StateController<TState> : IController
		where TState : IState
	{
		protected readonly Dictionary<string, TState> _states  = new Dictionary<string, TState>();
		protected string _activeState;

		public StateController(params TState[] states)
		{
			foreach (var state in states)
			{
				_states.Add(state.Name, state);
			}
		}

		public void SetState(string name)
		{
			var newState = _states[name];
			_activeState = name;
			newState.ChangeStateEvent += ChangeState;
			newState.Enter();
		}

		public void ChangeState(string name)
		{
			var newState = _states[name];
			var prevState = _states[_activeState];

			_activeState = name;

			prevState.ChangeStateEvent -= ChangeState;
			newState.ChangeStateEvent += ChangeState;

			prevState.Exit();
			newState.Enter();
		}

		public void Tick(float deltaTime)
		{
			_states[_activeState].Tick(deltaTime);
		}

		public void Initialize()
		{
			foreach (var state in _states.Values)
			{
				state.Initialize();
			}
		}

		public void Terminate()
		{
			foreach (var state in _states.Values)
			{
				state.Terminate();
			}
		}
	}
}