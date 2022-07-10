# solipair

Multiplayer competative solitaire game

## Todo

### Must

- Discard to oponent's player's discard pile
	- Rule: if (card being placed needs to be 1 above/below (wrapping supported) and be the same suite) OR (no cards in discar pile) then card placed on oponent's discard pile
	- Can only do this for non-ace card stack - drawn cards and cards in main play are allowed
- Ace piles
	- Can start any pile with any ace
	- Ensure we can take cards from the board and place on ace piles
		- Only allow draging for 1st and last card
		- If dragging last card - don't move enture stack
			- Improve dragging algorithm to only perform drag operations on all cards going up the stack from current card pos - makes things generic
		- If dragging last card - don't allow movement to the other stacks play stacks - only the ace stacks
- Tidy up UI
- Add card images to panels - possibly replace panels for image controls to make that easier

### Maybe

- More than 2 players
- Use something other than winforms - maybe convert to Blazor/Unity/Maui