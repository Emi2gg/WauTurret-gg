using System;
using UnityEngine;
using TMPro;

using MagasLib.SaveSystem;
public class SaveLoad : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;
   private int _counter = 0;

   private Transform _player;
   private BasicSave _save;
   private void Start()
   {
      BasicSave? tempSave = SaveData.Load<BasicSave>("data1");
      if (tempSave == null)
      {
         _text.SetText("NO SAVE DATA");
         _save = new BasicSave
         {
            x = _player.position.x,
            y = _player.position.y,
            z = _player.position.z,
            level = 10,
            mapName = "School parkinglot"
         };
         SaveData.Save(_save,"data1");
         transform.position = new Vector3(_save.x, _save.y, _save.z);
         
      }
      

      // _counter = PlayerPrefs.GetInt("TimeOpen", 0);
      // _counter++;
      // _text.SetText($"Times Game Has Been open = {_counter}");
      // PlayerPrefs.SetInt("TimeOpen",_counter);
      // PlayerPrefs.SetFloat("PlayerX",_player.position.x);
      // PlayerPrefs.SetFloat("PlayerY",_player.position.y);
      // PlayerPrefs.SetFloat("PlayerZ",_player.position.z);
   }
}
