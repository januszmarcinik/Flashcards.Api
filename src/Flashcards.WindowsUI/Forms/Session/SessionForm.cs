using System;
using System.Windows.Forms;
using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Models;
using Flashcards.WindowsUI.Models.Sessions;
using Flashcards.WindowsUI.Services;

namespace Flashcards.WindowsUI.Forms.Session
{
    public partial class SessionForm : FlashcardsForm
    {
        private readonly Topic _topic;
        private readonly string _category;
        private readonly string _deck;
        private readonly SessionsService _sessionsService;

        private SessionState _sessionState;

        public SessionForm(Topic topic, string category, string deck)
        {
            _topic = topic;
            _category = category;
            _deck = deck;
            _sessionsService = new SessionsService();

            InitializeComponent();

            _sessionState = _sessionsService.GetSessionState(topic, category, deck);
            SetControls();
        }

        public void SetControls()
        {
            tbTitle.Text = _sessionState.Card.Title;
            tbQuestion.Text = _sessionState.Card.Question;
            tbAnswer.Text = _sessionState.Card.Answer;
            lblProgress.Text = $"{_sessionState.ActualCount} / {_sessionState.TotalCount}";
            pbProgress.Value = _sessionState.Percentage;
        }

        private void btnDoNotYet_Click(object sender, EventArgs e)
        {
            var command = new ApplySessionCardCommand(_sessionState.Card.CardId, SessionCardStatus.DoNotYet);
            ApplySessionState(command);
        }

        private void btnNotSure_Click(object sender, EventArgs e)
        {
            var command = new ApplySessionCardCommand(_sessionState.Card.CardId, SessionCardStatus.NotSure);
            ApplySessionState(command);
        }

        private void btnAlreadyDone_Click(object sender, EventArgs e)
        {
            var command = new ApplySessionCardCommand(_sessionState.Card.CardId, SessionCardStatus.AlreadyDone);
            ApplySessionState(command);
        }

        private void ApplySessionState(ApplySessionCardCommand command)
        {
            _sessionState = _sessionsService.ApplySessionCard(_topic, _category, _deck, command);
            if (_sessionState.IsFinished)
            {
                lblProgress.Text = $"{_sessionState.ActualCount} / {_sessionState.TotalCount}";
                pbProgress.Value = _sessionState.Percentage;
                MessageBox.Show("The session is finished.");
                Close();
            }
            else
            {
                SetControls();
            }
        }
    }
}
