using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Player.Tools;

[CreateAssetMenu(fileName = "ToolData", menuName = "SO/ToolData", order = 1)]
public class ToolsData : ScriptableObject
{

    public List<ToolParameters> toolParameters;

    /// <summary>
    /// Search tool from the list
    /// </summary>
    /// <param name="toolType">Type tool</param>
    /// <returns>Tool parameters </returns>
    public ToolParameters GetTollWithType(ToolsController.ToolType toolType)
    {
        foreach(ToolParameters tp in toolParameters)
        {
            if (tp.toolType == toolType)
                return tp;
        }
        return null;
    }

}
