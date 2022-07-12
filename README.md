# solipair

Multiplayer competative solitaire game

## Todo

### Must

- Allow dragging from the board to the opponent's discard pile - similar issues to the Ace piles
- Ace piles
	- Can start any pile with any ace
	- Ensure we can take cards from the board and place on ace piles
		- Only allow draging for 1st and last card
		- If dragging last card - don't move enture stack
			- Improve dragging algorithm to only perform drag operations on all cards going up the stack from current card pos - makes things generic
		- If dragging last card - don't allow movement to the other stacks play stacks - only the ace stacks and opponent's discard pile
- Tidy up UI
- Add card images to panels - possibly replace panels for image controls to make that easier

### Maybe

- Use something other than winforms - maybe convert to Blazor/Unity/Maui
- More than 2 players