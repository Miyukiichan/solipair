namespace Solipair {
    public partial class Form1 : Form {
        const int CardWidth = 104;
        const int CardHeight = 150;
        Controller controller;
        Panel pP1Current;
        Panel pP2Current;
        Label lP1Current;
        Label lP2Current;
        public Stack<GUICard> skGUI1;
        public Stack<GUICard> skGUI2;
        public Stack<GUICard> skGUI3;
        public Stack<GUICard> skGUI4;
        private void InitCurrent(Panel p, Label l) {
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Width = CardWidth;
            p.Height = CardHeight;
            l.Parent = p;
        }
        private void InitCards(Panel p) {
            var conts = p.Controls.Cast<Control>();
            foreach (var cont in conts) {
                if (cont == null || cont.Tag == null) continue;
                if (cont.Tag.ToString() == "Card") {
                    cont.Height = CardHeight;
                    cont.Width = CardWidth;
                }
            }
        }
        public Form1() {
            InitializeComponent();
            skGUI1 = new Stack<GUICard>();
            skGUI2 = new Stack<GUICard>();
            skGUI3 = new Stack<GUICard>();
            skGUI4 = new Stack<GUICard>();
            //Init card sizes
            InitCards(pP1);
            InitCards(pP2);
            //Init current drawn card placeholders
            pP1Current = new Panel();
            lP1Current = new Label();
            pP2Current = new Panel();
            lP2Current = new Label();
            InitCurrent(pP1Current, lP1Current);
            InitCurrent(pP2Current, lP2Current);
            pP1Current.Parent = pP1;
            pP2Current.Parent = pP2;
            pP1Current.Anchor = AnchorStyles.Right;
            pP2Current.Anchor = AnchorStyles.Left;
            pP1Current.Left = pP1.Width - pP1Current.Width - 20;
            pP2Current.Left = 0;
            //Start game
            controller = new Controller();
            Reset();
        }
        private void ResetGUIStack(Stack<GUICard> sk, Panel p) {
            while (sk.Any()) {
                p.Controls.Remove(sk.Pop().Panel);
            }
        }
        public void Reset() {
            pP1Current.Hide();
            pP2Current.Hide();
            ResetGUIStack(skGUI1, pCard1);
            ResetGUIStack(skGUI2, pCard2);
            ResetGUIStack(skGUI3, pCard3);
            ResetGUIStack(skGUI4, pCard4);
            controller.StartGame();
            lP1Deck.Text = controller.P1.Deck.Count().ToString();
            lP2Deck.Text = controller.P2.Deck.Count().ToString();
            lPlayerTurn.Text = controller.PlayerTurn();
            lP1Discard.Text = "0";
            lP1DiscardTop.Text = "";
            lP2Discard.Text = "0";
            lP2DiscardTop.Text = "";
        }
        private void pP1Deck_MouseClick(object sender, MouseEventArgs e) {
            Card? card = controller.P1Draw();
            if (card == null) return;
            lP1Current.Text = card.Text();
            pP1Current.Show();
            lP1Deck.Text = controller.P1.Deck.Count().ToString();
        }
        private void bReset_Click(object sender, EventArgs e) {
            Reset();
        }
        private void pP2Deck_MouseClick(object sender, MouseEventArgs e) {
            Card? card = controller.P2Draw();
            if (card == null) return;
            lP2Current.Text = card.Text();
            pP2Current.Show();
            lP2Deck.Text = controller.P2.Deck.Count().ToString();
        }
        public void SwitchPlayer() {
            pP1Current.Hide();
            pP2Current.Hide();
            controller.SwitchPlayer();
            lPlayerTurn.Text = controller.PlayerTurn();
        }
        private void pCard1_MouseClick(object? sender, MouseEventArgs e) {
            var c = AddCard(controller.sk1, skGUI1, pCard1);
            if (c == null) return;
            c.Panel.MouseClick += pCard1_MouseClick;
        }
        private void pCard2_MouseClick(object? sender, MouseEventArgs e) {
            var c = AddCard(controller.sk2, skGUI2, pCard2);
            if (c == null) return;
            c.Panel.MouseClick += pCard2_MouseClick;
        }
        private void pCard3_MouseClick(object? sender, MouseEventArgs e) {
            var c = AddCard(controller.sk3, skGUI3, pCard3);
            if (c == null) return;
            c.Panel.MouseClick += pCard3_MouseClick;
        }
        private void pCard4_MouseClick(object? sender, MouseEventArgs e) {
            var c = AddCard(controller.sk4, skGUI4, pCard4);
            if (c == null) return;
            c.Panel.MouseClick += pCard4_MouseClick;
        }
        private GUICard? AddCard(Stack<Card>? sk, Stack<GUICard>? skGUI, Panel p) {
            if (sk == null || skGUI == null) return null;
            Card? current = controller.ActivePlayer.Current;
            if (current == null) return null;
            bool added = controller.AddToStack(sk, current);
            if (!added) return null;
            var c = new GUICard(current);
            skGUI.Push(c);
            int offset = (skGUI.Count() - 1) * 25;
            c.Panel.Parent = p;
            c.Panel.Top = offset;
            p.Controls.SetChildIndex(c.Panel, 0);
            SwitchPlayer();
            return c;
        }

        private void pP1Discard_MouseClick(object sender, MouseEventArgs e) {
            if (controller.ActivePlayer != controller.P1) return;
            var discarded = controller.Discard();
            if (!discarded) return;
            lP1DiscardTop.Text = controller.ActivePlayer.Discard.Peek().Text();
            lP1Discard.Text = controller.ActivePlayer.Discard.Count().ToString();
            pP1Current.Hide();
            SwitchPlayer();
        }

        private void pP2Discard_MouseClick(object sender, MouseEventArgs e) {
            if (controller.ActivePlayer != controller.P2) return;
            var discarded = controller.Discard();
            if (!discarded) return;
            lP2DiscardTop.Text = controller.ActivePlayer.Discard.Peek().Text();
            lP2Discard.Text = controller.ActivePlayer.Discard.Count().ToString();
            pP2Current.Hide();
            SwitchPlayer();
        }
    }
    public class GUICard {
        const int CardWidth = 104;
        const int CardHeight = 150;
        public Panel Panel;
        public Label Label;
        public Card Card;
        public GUICard(Card c) {
            Panel = new Panel();
            Panel.Height = CardHeight;
            Panel.Width = CardWidth;
            Panel.BorderStyle = BorderStyle.FixedSingle;
            Panel.Anchor = AnchorStyles.Top;
            Panel.BringToFront();
            Label = new Label();
            Label.Parent = Panel;
            Label.Text = c.Text();
            Card = c;
        }
    }
    public enum TSuit { Heart, Diamond, Spade, Club }
    public enum TColour { Red, Black }
    public class Card {
        public TSuit Suit;
        public int Value;
        public TColour GetColour() {
            return (Suit == TSuit.Heart || Suit == TSuit.Diamond) ? TColour.Red : TColour.Black;
        }
        public string Text() {
            var val = "";
            switch (Value) {
                case 1:
                val = "A";
                break;
                case 11:
                val = "J";
                break;
                case 12:
                val = "Q";
                break;
                case 13:
                val = "K";
                break;
                default:
                val = Value.ToString();
                break;
            }
            var suit = Suit.ToString();
            return $"{val} of {suit}s";
        }
    }
    public class Player {
        public Stack<Card> Deck;
        public Stack<Card> Discard;
        public Card? Current;
        public string Name;
        public Player(string name) {
            Deck = new Stack<Card>();
            Discard = new Stack<Card>();
            Current = null;
            Name = name;
        }
        public void ClearCards() {
            Deck.Clear();
            Discard.Clear();
        }
        public Card? Draw() {
            if (Current != null) return Current;
            if (!Deck.Any()) return null;
            Current = Deck.Pop();
            return Current;
        }
    }
    public class Controller {
        public Player P1;
        public Player P2;
        public Player ActivePlayer;
        public Stack<Card> sk1;
        public Stack<Card> sk2;
        public Stack<Card> sk3;
        public Stack<Card> sk4;
        public Controller() { 
            P1 = new Player("Player 1");
            P2 = new Player("Player 2");
            ActivePlayer = P1;
            sk1 = new Stack<Card>();
            sk2 = new Stack<Card>();
            sk3 = new Stack<Card>();
            sk4 = new Stack<Card>();
        }
        public Card? P1Draw() {
            if (ActivePlayer != P1) return null;
            return P1.Draw();
        }
        public Card? P2Draw() {
            if (ActivePlayer != P2) return null;
            return P2.Draw();
        }
        public string PlayerTurn() {
            return $"{ActivePlayer.Name}'s turn";
        }
        public bool AddToStack(Stack<Card> sk, Card c) {
            if (ActivePlayer.Current != c) return false;
            if (sk.Any()) {
                if (sk.Peek().GetColour() == c.GetColour()) return false;
                if ((sk.Peek().Value - c.Value) != 1) return false;
            }
            sk.Push(c);
            ActivePlayer.Current = null;
            return true;
        }
        public void SwitchPlayer() {
            ActivePlayer.Current = null;
            if (ActivePlayer == P1)
                ActivePlayer = P2;
            else
                ActivePlayer = P1;
        }
        public bool Discard() {
            if (ActivePlayer.Current == null) return false;
            ActivePlayer.Discard.Push(ActivePlayer.Current);
            ActivePlayer.Current = null;
            return true;
        }
        public void StartGame() {
            P1.ClearCards();
            P2.ClearCards();
            var deck = new List<Card>();
            for (int i = 0; i < 4; i++) {
                //Ace = 1, King = 14
                for (int j = 1; j < 14; j++) {
                    var card = new Card();
                    card.Value = j;
                    card.Suit = (TSuit)i;
                    deck.Add(card);
                }
            }
            var rnd = new Random();
            deck = deck.OrderBy(card => rnd.Next()).ToList();
            var decks = deck.Chunk(26);
            P1.Deck = new Stack<Card>(decks.First());
            P2.Deck = new Stack<Card>(decks.Last());
            sk1.Clear();
            sk2.Clear();
            sk3.Clear();
            sk4.Clear();
            ActivePlayer = P1;
        }
    }
}