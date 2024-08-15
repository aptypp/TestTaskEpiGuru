using System;
using Scripts.Environment;
using Scripts.GameModes;
using Scripts.Player;
using Scripts.UI.Panels;
using Scripts.UI.Popups;
using ThirdParty;
using UnityEngine;
using Utilities;

namespace Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        #region Panels

        [SerializeField]
        private MenuPanel _menuPanel;

        [SerializeField]
        private ActionPanel _actionPanel;

        #endregion

        #region Popups

        [SerializeField]
        private WinPopup _winPopup;

        [SerializeField]
        private LosePopup _losePopup;

        [SerializeField]
        private PausePopup _pausePopup;

        #endregion

        #region Environment

        [SerializeField]
        private Camera _meshCamera;

        [SerializeField]
        private WorldView _worldView;

        [SerializeField]
        private PlayerView _playerView;

        #endregion

        private PlayerData _playerData;
        private PauseService _pauseService;
        private PlayerMovement _playerMovement;
        private IpLookUpService _lookUpService;
        private ClassicGameMode _classicGameMode;

        private void Start()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

            var oneSignal = new OneSignalService("635c5f12-bb1c-4e8a-92a5-65636c604328");
            oneSignal.Initialize();

            _lookUpService = new IpLookUpService();

            _lookUpService.LookUp(
                HandleLookUpData,
                () => Debug.LogError("Lookup failed"));
        }

        private void Update()
        {
            _classicGameMode?.Update();
        }

        private void LateUpdate()
        {
            _classicGameMode?.LateUpdate();
        }

        private void ConfigureUI()
        {
            _menuPanel.PlayButton.onClick.AddListener(
                () =>
                {
                    _menuPanel.Hide();
                    _worldView.Show();
                    _actionPanel.Show();
                    _classicGameMode.Start();
                });

            _actionPanel.MenuButton.onClick.AddListener(
                () =>
                {
                    _menuPanel.Show();
                    _worldView.Hide();
                    _actionPanel.Hide();
                    _classicGameMode.Stop();
                    _classicGameMode.Reset();
                });

            _actionPanel.Touchpad.PositionChanged += normalized => _playerMovement.SetHorizontalPosition(normalized);

            _actionPanel.PauseButton.onClick.AddListener(
                () =>
                {
                    _pausePopup.Show();
                    _pauseService.Pause();
                });

            _playerData.Score.Changed += score => { _actionPanel.ScoreText.text = $"Score {score}"; };

            _winPopup.ContinueButton.onClick.AddListener(
                () =>
                {
                    _classicGameMode.Reset();
                    _winPopup.Hide();
                    _actionPanel.Hide();
                    _menuPanel.Show();
                });

            _losePopup.ContinueButton.onClick.AddListener(
                () =>
                {
                    _classicGameMode.Reset();
                    _losePopup.Hide();
                    _actionPanel.Hide();
                    _menuPanel.Show();
                });

            _pausePopup.ContinueButton.onClick.AddListener(
                () =>
                {
                    _pauseService.Unpause();
                    _pausePopup.Hide();
                });

            _classicGameMode.Won += () =>
            {
                _winPopup.Show();
                _winPopup.ScoreText.text = $"Score {_playerData.Score.Value}";
            };

            _classicGameMode.Lose += () => { _losePopup.Show(); };
        }

        private void InitializeServices()
        {
            _pauseService = new PauseService();
            _playerData = new PlayerData();
            _playerMovement = new PlayerMovement(_playerData);
            _classicGameMode = new ClassicGameMode(
                _meshCamera,
                _worldView,
                _playerData,
                _playerView,
                _playerMovement);
        }

        private void HandleLookUpData(
            LookUpData data)
        {
            if (data.country.Equals("Ukraine"))
            {
                StartGame();
                return;
            }

            ShowWikipedia();
        }

        private void ShowWikipedia()
        {
            var webview = new WebViewService();
            webview.Show("https://www.wikipedia.org/");
        }

        private void StartGame()
        {
            InitializeServices();
            ConfigureUI();
            _menuPanel.Show();
        }
    }
}