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
        private Point _mouseDownLocation;
        private Panel? _startingPanel;
        private void InitCurrent(out Panel p, out Label l) {
            p = new Panel();
            l = new Label();
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Width = CardWidth;
            p.Height = CardHeight;
            l.Parent = p;
            p.Parent = this;
            InitCurrentEvents(p);
            InitCurrentEvents(l);
        }
        private void InitCard(Panel p) {
            p.Height = CardHeight;
            p.Width = CardWidth;
        }
        private void InitCurrentEvents(Control c) {
            c.MouseMove += CardMoved;
            c.MouseDown += CardMouseDown;
            c.MouseUp += CurrentMouseUp;
        }

        public Form1() {
            InitializeComponent();
            skGUI1 = new Stack<GUICard>();
            skGUI2 = new Stack<GUICard>();
            skGUI3 = new Stack<GUICard>();
            skGUI4 = new Stack<GUICard>();
            //Init card sizes
            InitCard(pP1Deck);
            InitCard(pP1Discard);
            InitCard(pP2Deck);
            InitCard(pP2Discard);
            //Init current drawn card placeholders
            InitCurrent(out pP1Current, out lP1Current);
            InitCurrent(out pP2Current, out lP2Current);
            pP1Current.Anchor = AnchorStyles.Right;
            pP2Current.Anchor = AnchorStyles.Left;

            //Start game
            controller = new Controller();
            Reset();
        }

        private void CardMouseDown(object? sender, MouseEventArgs e) {
            _mouseDownLocation = e.Location;
            Panel? p = GetSenderPanel(sender);
            if (p == null) return;
            p = p.Parent as Panel;
            if (p == null) return;
            _startingPanel = p;
        }
        private Panel? GetSenderPanel(object? sender) {
            Panel? p = sender as Panel;
            //Assume event is coming from the label if not the panel - we can get the panel from the label parent
            if (p == null) {
                Label? l = sender as Label;
                if (l == null) return null;
                p = l.Parent as Panel;
                if (p == null) return null;
            }
            return p;
        }

        private void CardMoved(object? sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            Panel? p = GetSenderPanel(sender);
            if (p == null) return;
            //Make it so cards in play get moved out from the board panels so we can move them around the whole screen
            p.Parent = this;
            p.Parent.Controls.SetChildIndex(p, 0);
            p.Location = new Point(e.X + p.Left - _mouseDownLocation.X, e.Y + p.Top - _mouseDownLocation.Y);
        }
        private void RemovePlayCardEvents(Control c) {
            c.MouseDown -= CardMouseDown;
            c.MouseUp -= CardMouseUp;
            c.MouseMove -= PlayCardMoved;
        }
        private void AddPlayCardEvents(Control c) {
            c.MouseDown += CardMouseDown;
            c.MouseUp += CardMouseUp;
            c.MouseMove += PlayCardMoved;
        }
        private void ResetStack(Stack<GUICard> sk, Panel pBase) {
            for (int i = sk.Count() - 1; i >= 0; i--) {
                var element = sk.ElementAt(i);
                Panel panel = element.Panel;
                panel.Parent = pBase;
                panel.Location = new Point(0, GetCardPos(skGUI1, sk.Count() - 1 - i));
                pBase.Controls.SetChildIndex(panel, i);
                RemovePlayCardEvents(panel);
                RemovePlayCardEvents(element.Label);
            }
            if (!sk.Any()) return;
            var e = sk.ElementAt(sk.Count() - 1);
            AddPlayCardEvents(e.Panel);
            AddPlayCardEvents(e.Label);
        }
        private void ResetCardPos() {
            pP1Current.Location = new Point(pP1Discard.Right + 20, pP1Discard.Top);
            pP2Current.Location = new Point(pP2Discard.Left - pP2Current.Width - 20, pP2Discard.Top);
            ResetStack(skGUI1, pCard1);
            ResetStack(skGUI2, pCard2);
            ResetStack(skGUI3, pCard3);
            ResetStack(skGUI4, pCard4);
        }
        private void CurrentMouseUp(object? sender, MouseEventArgs e) {
            Panel? p = GetSenderPanel(sender);
            if (p == null) return;
            var disc = pP1Discard;
            if (p == pP2Current)
                disc = pP2Discard;
            if (Collided(p, disc)) {
                if (p == pP1Current)
                    pP1Discard_MouseClick(sender, e);
                else
                    pP2Discard_MouseClick(sender, e);
            }
            else if (Collided(p, pCard1))
                pCard1_MouseClick(sender, e);
            else if (Collided(p, pCard2))
                pCard2_MouseClick(sender, e);
            else if (Collided(p, pCard3))
                pCard3_MouseClick(sender, e);
            else if (Collided(p, pCard4))
                pCard4_MouseClick(sender, e);
            else
                ResetCardPos();
        }

        private void CardMouseUp(object? sender, MouseEventArgs e) {
            if (_startingPanel == null) return;
            Panel? p = GetSenderPanel(sender);
            if (p == null) return;
            Stack<Card>? skFrom = null;
            Stack<GUICard>? skGUIFrom = null;
            if (_startingPanel == pCard1) {
                skFrom = controller.sk1;
                skGUIFrom = skGUI1;
            }
            else if (_startingPanel == pCard2) {
                skFrom = controller.sk2;
                skGUIFrom = skGUI2;
            }
            else if (_startingPanel == pCard3) {
                skFrom = controller.sk3;
                skGUIFrom = skGUI3;
            }
            else if (_startingPanel == pCard4) {
                skFrom = controller.sk4;
                skGUIFrom = skGUI4;
            }
            if (skFrom == null || skGUIFrom == null) return;
            bool reset = true;
            if (_startingPanel != pCard1 && Collided(p, pCard1)) {
                reset = !MoveStack(skFrom, skGUIFrom, _startingPanel, controller.sk1, skGUI1, pCard1);
            }
            else if (_startingPanel != pCard2 && Collided(p, pCard2)) {
                reset = !MoveStack(skFrom, skGUIFrom, _startingPanel, controller.sk2, skGUI2, pCard2);
            }
            else if (_startingPanel != pCard3 && Collided(p, pCard3)) {
                reset = !MoveStack(skFrom, skGUIFrom, _startingPanel, controller.sk3, skGUI3, pCard3);
            }
            else if (_startingPanel != pCard4 && Collided(p, pCard4)) {
                reset = !MoveStack(skFrom, skGUIFrom, _startingPanel, controller.sk4, skGUI4, pCard4);
            }
            if (reset) {
                //Workaround for visual bug - single reset does not stack the cards properly visually - just call the function twice
                ResetCardPos();
                ResetCardPos();
            }
        }
        private bool MoveStack(Stack<Card> skFrom, Stack<GUICard> skGUIFrom, Panel pFrom, Stack<Card> skTo, Stack<GUICard> skGUITo, Panel pTo) {
            if (!controller.MergeStacks(skFrom, skTo)) return false;
            Stack<GUICard> tmp = new Stack<GUICard>();
            while (skGUIFrom.Any()) 
                tmp.Push(skGUIFrom.Pop());
            while (tmp.Any()) 
                skGUITo.Push(tmp.Pop());
            //Workaround for visual bug - single reset does not stack the cards properly visually - just call the function twice
            ResetStack(skGUITo, pTo);
            ResetStack(skGUITo, pTo);
            return true;
        }

        private bool Collided(Control p1, Control p2) {
            var c = new Point(p1.Left + (p1.Width / 2), p1.Top + (p1.Height / 2));
            return (c.X < p2.Right && c.X > p2.Left && c.Y > p2.Top && c.Y < p2.Bottom);
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
            ResetCardPos();
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
            ResetCardPos();
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
        private int GetCardPos(Stack<GUICard> skGUI, int index = -1) {
            if (index < 0)
                index = skGUI.Count() - 1;
            return index * 25;
        }
        private GUICard? AddCard(Stack<Card>? sk, Stack<GUICard>? skGUI, Panel p) {
            if (sk == null || skGUI == null) return null;
            Card? current = controller.ActivePlayer.Current;
            if (current == null) return null;
            bool added = controller.AddToStack(sk, current);
            if (!added) return null;
            var c = new GUICard(current);
            skGUI.Push(c);
            c.Panel.Parent = p;
            c.Panel.Top = GetCardPos(skGUI);
            p.Controls.SetChildIndex(c.Panel, 0);
            if (skGUI.Count == 1) {
                //c.Panel.MouseMove += CardMoved;
                c.Panel.MouseMove += PlayCardMoved;
                c.Panel.MouseDown += CardMouseDown;
                c.Panel.MouseUp += CardMouseUp;
                //c.Label.MouseMove += CardMoved;
                c.Label.MouseMove += PlayCardMoved;
                c.Label.MouseDown += CardMouseDown;
                c.Label.MouseUp += CardMouseUp;
            }
            SwitchPlayer();
            return c;
        }

        private void PlayCardMoved(object? sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;
            Stack<GUICard>? gc = null;
            if (_startingPanel == pCard1)
                gc = skGUI1;
            else if (_startingPanel == pCard2)
                gc = skGUI2;
            else if (_startingPanel == pCard3)
                gc = skGUI3;
            else if (_startingPanel == pCard4)
                gc = skGUI4;
            if (gc == null) return;
            foreach (var c in gc) {
                CardMoved(c.Panel, e);
            }
        }

        private void pP1Discard_MouseClick(object? sender, MouseEventArgs e) {
            if (controller.ActivePlayer != controller.P1) return;
            var discarded = controller.Discard();
            if (!discarded) return;
            lP1DiscardTop.Text = controller.ActivePlayer.Discard.Peek().Text();
            lP1Discard.Text = controller.ActivePlayer.Discard.Count().ToString();
            pP1Current.Hide();
            SwitchPlayer();
        }

        private void pP2Discard_MouseClick(object? sender, MouseEventArgs e) {
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
        public bool CanAddToStack(Stack<Card> sk, Card c, bool checkCurrent = true) {
            if (checkCurrent && ActivePlayer.Current != c) return false;
            if (sk.Any()) {
                if (sk.Peek().GetColour() == c.GetColour()) return false;
                if ((sk.Peek().Value - c.Value) != 1) return false;
            }
            return true;
        }
        public bool AddToStack(Stack<Card> sk, Card c) {
            if (!CanAddToStack(sk, c)) return false;
            sk.Push(c);
            ActivePlayer.Current = null;
            return true;
        }
        public bool MergeStacks(Stack<Card> from, Stack<Card> to) {
            if (!CanAddToStack(to, from.Last(), false)) return false;
            Stack<Card> tmp = new Stack<Card>();
            while (from.Any()) 
                tmp.Push(from.Pop());
            while (tmp.Any())
                to.Push(tmp.Pop());
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