﻿using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.Entity.AI.Task.Tasks;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Input.History;
using System;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    public class TillingActionHandler
    {
        public TillingActionHandler()
        {
            InputHistory.InputAdded += this.InputHistory_InputAdded;
        }

        private void InputHistory_InputAdded()
        {
            HistoricalInput last = InputHistory.History.Last();

            if (last.ActionSelected == ActionSelected.Till)
            {
                foreach (HasComponents item in last.Selected)
                {
                    ComponentSelectable selected = item.GetExactComponent<ComponentSelectable>();
                    Tile tile = World.GetTile(RenderInfo.DimensionID, selected.MapLocation.X, selected.MapLocation.Y);

                    if (tile.HasComponent<ComponentTillable>()
                        && tile.ImpendingAction == ActionSelected.None
                        && tile.MainObject == null)
                    {
                        TillTask task = new TillTask(tile.GetExactComponent<ComponentSelectable>().MapLocation, Guid.NewGuid());
                        tile.ImpendingAction = ActionSelected.Till;
                        TaskManager.Manager.AddTask(task);
                    }
                }
            }
        }
    }
}