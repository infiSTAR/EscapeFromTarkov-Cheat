﻿using System.Collections;
using System.Collections.Generic;
using Comfort.Common;
using EFT;
using EFT.Interactive;
using EscapeFromTarkovCheat.Utils;
using UnityEngine;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
    public class ItemESP : MonoBehaviour
    {
        private IEnumerable<LootItem> _lootItems;
        private void Start()
        {
            InvokeRepeating(nameof(GetItems), 10f, 10f);
        }

        private void OnGUI()
        {
            if (Settings.DrawLootItems)
            {
                DrawItemESP();
            }
        }

        public void DrawItemESP()
        {
            if (_lootItems == null)
                return;

            foreach (LootItem lootItem in _lootItems)
            {
                if (lootItem == null)
                    continue;

                float distance = Vector3.Distance(Camera.main.transform.position, lootItem.transform.position);
                Vector3 boundingVector = Camera.main.WorldToScreenPoint(lootItem.transform.position);

                if (boundingVector.z > 0.01 && distance <= Settings.DrawLootItemsDistance)
                {
                    if (lootItem.name.Contains("key") ||
                        lootItem.name.Contains("usb") ||
                        lootItem.name.Contains("alkali") ||
                        lootItem.name.Contains("ophalmo") ||
                        lootItem.name.Contains("gunpowder") ||
                        lootItem.name.Contains("phone") ||
                        lootItem.name.Contains("money") ||
                        lootItem.name.Contains("document") ||
                        lootItem.name.Contains("quest") ||
                        lootItem.name.Contains("spark") ||
                        lootItem.name.Contains("grizzly") ||
                        lootItem.name.Contains("sv-98") ||
                        lootItem.name.Contains("sv98") ||
                        lootItem.name.Contains("rsas") ||
                        lootItem.name.Contains("salewa") ||
                        lootItem.name.Equals("bitcoin") ||
                        lootItem.name.Contains("dvl") ||
                        lootItem.name.Contains("m4a1") ||
                        lootItem.name.Contains("roler") ||
                        lootItem.name.Contains("chain") ||
                        lootItem.name.Contains("wallet") ||
                        lootItem.name.Contains("RSASS") ||
                        lootItem.name.Contains("glock") ||
                        lootItem.name.Contains("SA-58"))
                    {
                        string text = $"{lootItem.name} - [{(int)distance}]m";

                        GUI.color = Color.yellow;
                        GUI.Label(new Rect(boundingVector.x - 50f, Screen.height - boundingVector.y, 100f, 50f), text);
                    }
                }
            }
        }

        public void GetItems()
        {
            GameWorld world = Singleton<GameWorld>.Instance;

            if (world != null)
            {
                if (Settings.DrawLootItems)
                    _lootItems = FindObjectsOfType<LootItem>();
            }
        }
    }
}