//----------------------------------------------------------------
//
//  Copyright (c) 2014 All Rights Reserved
//  Valter Costa
//
//----------------------------------------------------------------

using GenericAI.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GenericAI.Algorithms
{
    public class AStar
    {
        private State originalState;
        private List<Operator> operators;
        private Heuristic heuristic;
        private List<State> visitedStates;
        private PriorityStateQueue states;
        private Thread thread;

        public event EventHandler<ResultEventArgs> OnSearchComplete;
        public bool IsRunning
        {
            get
            {
                return thread != null && thread.IsAlive;
            }
        }

        public AStar(State original, List<Operator> operators, Heuristic heuristic)
        {
            if (original == null)
            {
                throw new ArgumentNullException("Original state cannot be null.");
            }

            if (operators == null)
            {
                throw new ArgumentNullException("The operator list cannot be null.");
            }

            if (operators.Count == 0)
            {
                throw new ArgumentException("The operator list cannot be empty.");
            }

            if (heuristic == null)
            {
                throw new ArgumentNullException("Heuristic cannot be null.");
            }

            this.states = new PriorityStateQueue();
            this.visitedStates = new List<State>();
            this.thread = new Thread(RunAStar);

            this.originalState = original;
            this.operators = operators;
            this.heuristic = heuristic;  
        }

        public void StartSearch()
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("Algorithm is already running");
            }

            if (this.thread == null)
            {
                throw new InvalidOperationException("The algorithm was already executed, to use it again make another instance");
            }

            this.thread.Start();
        }

        private void RunAStar()
        {
            this.states.Push(originalState);
            Result result = null;

            while (!states.IsEmpty)
            {
                State state = states.Pop();
                if (state.IsGoal())
                {
                    result = new Result(state);
                    break;
                }

                visitedStates.Add(state);

                if (state.IgnoreStateAndChilds())
                {
                    continue;
                }

                foreach (var item in operators)
                {
                    State newState = null;

                    try
                    {
                        newState = item.Apply(state.Copy());
                        newState.Parent = state;
                        newState.Operator = item;
                        newState.CostFromBeginning = state.CostFromBeginning + heuristic.CostBetweenStates(state, newState);
                        newState.EstimatedTotalCost = newState.CostFromBeginning + heuristic.EstimateCostToGoal(newState);

                    }
                    catch (Exception ex)
                    {
                        if (OnSearchComplete != null)
                        {
                            OnSearchComplete(this, new ResultEventArgs(ex));
                        }
                        return;
                    }

                    if (!visitedStates.Contains(newState))
                    {
                        if (!states.Contains(newState))
                        {
                            states.Push(newState);
                        }
                        else
                        {
                            State oldSimilarState = states.GetSimilar(newState);
                            if (oldSimilarState.CostFromBeginning > newState.CostFromBeginning)
                            {
                                states.Remove(oldSimilarState);
                                states.Push(newState);
                            }
                        }
                    }
                         
                }

            }

            if (OnSearchComplete != null)
            {
                OnSearchComplete(this, new ResultEventArgs(result));
            }

            this.thread = null;
        }

    }
}
