using System;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike
{
    public class LobbyScreen : BaseScreen
    {
        [SerializeField] private ChooseCharacter _chooseCharacter;

        [Header("Buttons")]
        [SerializeField] private Button _firstPlayerButton;
        [SerializeField] private Button _secondPlayerButton;

        private void Awake()
        {
            _firstPlayerButton.onClick.AddListener(_chooseCharacter.TakeSoldier);
            _secondPlayerButton.onClick.AddListener(_chooseCharacter.TakeStormtrooper);
        }
    }
}