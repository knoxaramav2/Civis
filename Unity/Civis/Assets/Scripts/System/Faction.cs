using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//lists all available units and buildings belonging to a faction
public static class Faction
{
    public static List<ActorSheet> ActorSheets;
    public static List<BuildingSheet> BuildingSheets;

    public static void LoadFactionInfo()
    {
        var dir = Directory.GetCurrentDirectory();
        var files = Directory.GetFiles(dir + "\\Assets\\Resources\\GameSheets", "*.csv");

        foreach (var f in files)
        {
            LoadFactionFile(f);
        }
    }

    public static void Init()
    {
        ActorSheets = new List<ActorSheet>();
        BuildingSheets = new List<BuildingSheet>();
    }

    private static void LoadFactionFile(string file)
    {
        string factionName = null;

        ActorSheet aSheet = null;
        BuildingSheet bSheet = null;

        using (var reader = new StreamReader(file))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var terms = line.Split(',');

                foreach (var term in terms)
                {
                    var touple = term.Split(':');

                    if (touple[0][0] == '#') continue;

                    switch (touple[0])
                    {
                        //general
                        case "fcnm": factionName = touple[1]; break;
                        case "end":

                            if (factionName == null)
                                Debug.LogError("No faction name set");

                            if (aSheet != null && bSheet != null)
                                Debug.LogError("Error - invalid sheet");
                            else if (aSheet != null)
                            {
                                aSheet.FactionName = factionName;
                                ActorSheets.Add(aSheet);
                                aSheet = null;
                            } else if (bSheet != null)
                            {
                                //bSheet
                                BuildingSheets.Add(bSheet);
                                bSheet = null;
                            }
                        break;

                        //actors
                        case "actor":
                            if (aSheet != null)
                                Debug.LogError("Error - multiple defined actor");
                            else
                                aSheet = new ActorSheet();
                            break;
                        //buildings
                        case "building":
                            if (bSheet != null)
                                Debug.LogError("Error - multiple defined building");
                            else
                                bSheet = new BuildingSheet();
                            break;
                    }
                }
            }
        }
    }

}