; * * * * * * * * * * * * * * * * * * * * *
; Stage 4
; Student Name: Dylan Rodwell
; Student Number: 105341089
; * * * * * * * * * * * * * * * * * * * * *
; R0 = function arguments and return values
; R1 = function arguments and return values
; R2 = function arguments
; R3 = function arguments
; R4 = stores player name
; R5 = stores matchsticks number
; R6 = stores removed matchsticks number
; R7 = stores current turn (0 = player, 1 = computer)
; * * * * * * * * * * * * * * * * * * * * *

// initializes game functions
MatchsticksGame:
// function retrieves game data
    PUSH {LR, R0, R2, R3}
    BL getGameInfo
    MOV R4, R2 // stores player name return value in R4
    MOV R5, R3 // stores matchsticks number return value in R5
    POP {LR, R0, R2, R3}

// function prints game data
    PUSH {LR, R0, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL writeGameInfo
    POP {LR, R0, R2, R3}

// functions that operate the game
gameFunctions:
// function prints update messages to display
    PUSH {LR, R0, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL gameMessage
    POP {LR, R0, R2, R3}

// function clears screen
    PUSH {LR, R0, R1, R2, R3, R4, R5}
    BL clearScreen
    POP {LR, R0, R1, R2, R3, R4, R5}

// function draws current amount of matchsticks
    PUSH {LR, R0, R1, R2, R3, R4, R5, R6, R7, R8}
    MOV R3, R5 // passes matchstick number via R3
    BL drawMatchstick
    POP {LR, R0, R1, R2, R3, R4, R5, R6, R7, R8}

// function handles player turn
    PUSH {LR, R0, R1, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL playerTurn
    MOV R6, R0 // stores removed matchsticks number in R6
    MOV R7, R1 // stores updated current turn in R7
    POP {LR, R0, R1, R2, R3}

// function updates matchstick count and prints win/lose messages to display
    PUSH {LR, R0, R1, R2, R3}
    MOV R0, R7 // passes current turn via R0
    MOV R1, R6 // passes removed matchsticks number via R2
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL gameUpdate
    MOV R5, R3 // updates new matchsticks value in R5
    POP {LR, R0, R1, R2, R3}

// function clears screen
    PUSH {LR, R0, R1, R2, R3, R4, R5}
    BL clearScreen
    POP {LR, R0, R1, R2, R3, R4, R5}

// function draws current amount of matchsticks
    PUSH {LR, R0, R1, R2, R3, R4, R5, R6, R7, R8}
    MOV R3, R5 // passes matchstick number via R3
    BL drawMatchstick
    POP {LR, R0, R1, R2, R3, R4, R5, R6, R7, R8}

// function checks if game is over
    PUSH {LR, R0, R1, R2, R3}
    MOV R3, R5 // passes matchstick number via R3
    BL playAgain
    CMP R0, #1 // checks what function to load next
    POP {LR, R0, R1, R2, R3}
    // game not over just continue
    BEQ MatchsticksGame // game start again
    BGT finish // game finished

// function handles computer turn
    PUSH {LR, R0, R1, R2, R3}
    MOV R3, R5 // passes matchstick number via R3
    BL compTurn
    MOV R6, R0 // updates removed matchstick number in R6
    MOV R7, R1 // updates current turn in R7
    POP {LR, R0, R1, R2, R3}

// function updates matchstick count and prints win/lose messages to display
    PUSH {LR, R0, R1, R2, R3}
    MOV R0, R7 // passes current turn via R0
    MOV R1, R6 // passes removed matchsticks number via R2
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL gameUpdate
    MOV R5, R3 // updates new matchsticks value in R5
    POP {LR, R0, R1, R2, R3}

// function clears screen
    PUSH {LR, R0, R1, R2, R3, R4, R5}
    BL clearScreen
    POP {LR, R0, R1, R2, R3, R4, R5}

// function draws current amount of matchsticks
    PUSH {LR, R0, R1, R2, R3, R4, R5, R6, R7, R8}
    MOV R3, R5 // passes matchstick number via R3
    BL drawMatchstick
    POP {LR, R0, R1, R2, R3, R4, R5, R6, R7, R8}

// function checks if game is over
    PUSH {LR, R0, R1, R2, R3}
    MOV R3, R5 // passes matchstick number via R3
    BL playAgain
    CMP R0, #1 // checks what function to load next
    POP {LR, R0, R1, R2, R3}
    BLT gameFunctions // game not over
    BEQ MatchsticksGame // game start again
    BGT finish // game finished

// function ends the program
finish:
// function clears screen
    PUSH {LR, R0, R1, R2, R3, R4, R5}
    BL clearScreen
    POP {LR, R0, R1, R2, R3, R4, R5}

    HALT

; * * * * * REGISTERS FOR DRAWING * * * * *
; R0 = pixel screen
; R1 = top colour
; R2 = bottom colour
; R3 = matchstick amount
; R4 = currently drawn matchsticks amount
; R5 = matchstick id
; R6 = pixel 1 pos
; R7 = pixel 2 pos
; R8 = pixel 3 pos
; * * * * * * * * * * * * * * * * * * * * *

// function draws current amount of matchsticks
drawMatchstick:
    CMP R3, #0
    BEQ endClearLoop
    MOV R4, #0
redraw:
    PUSH {LR, R0, R1, R2, R4, R5, R6, R7, R8}
    BL drawSingleMatchstick
    POP {LR, R0, R1, R2, R4, R5, R6, R7, R8}
    ADD R4, R4, #1 // increase matchsticks currently drawn by 1
    CMP R4, R3 // compares drawn matchstick amount with total matchstick amount
    BNE redraw // if not enough matchsticks are drawn, redraw
    RET

// function draws a single matchstick
drawSingleMatchstick:
    MOV R0, #.PixelScreen
    MOV R1, #0xe21335 // top matchstick colour
    MOV R2, #0xc1a061 // bottom matchstick colour
    MOV R6, #268 // set pos with 1 line gap
    MOV R5, #0 // id of current matchstick

// sets pos of pixel into defined row
setRow0:
    CMP R4, #9 // checks if  the current row is full
    BGT setRow1
    B checkPos
setRow1:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    CMP R4, #19 // checks if the current row is full
    BGT setRow2
    B checkPos
setRow2:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    CMP R4, #29 // checks if the current row is full
    BGT setRow3
    B checkPos
setRow3:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    CMP R4, #39 // checks if the current row is full
    BGT setRow4
    B checkPos
setRow4:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    CMP R4, #49 // checks if the current row is full
    BGT setRow5
    B checkPos
setRow5:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    CMP R4, #59 // checks if the current row is full
    BGT setRow6
    B checkPos
setRow6:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    CMP R4, #69 // checks if the current row is full
    BGT setRow7
    B checkPos
setRow7:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    CMP R4, #79 // checks if the current row is full
    BGT setRow8
    B checkPos
setRow8:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    CMP R4, #89 // checks if the current row is full
    BGT setRow9
    B checkPos
setRow9:
    ADD R5, R5, #10 // update matchstick id
    ADD R6, R6, #1024 // move pos to new row
    B checkPos

// checks matchstick pos to see if it is in the right spot
checkPos:
    CMP R5, R4 // checks if id matches currently drawn matchsticks
    BNE setPos
    CMP R5, #5
    BLT startDraw
    CMP R5, #10
    BLT addSpace
    CMP R5, #15
    BLT startDraw
    CMP R5, #20
    BLT addSpace
    CMP R5, #25
    BLT startDraw
    CMP R5, #30
    BLT addSpace
    CMP R5, #35
    BLT startDraw
    CMP R5, #40
    BLT addSpace
    CMP R5, #45
    BLT startDraw
    CMP R5, #50
    BLT addSpace
    CMP R5, #55
    BLT startDraw
    CMP R5, #60
    BLT addSpace
    CMP R5, #65
    BLT startDraw
    CMP R5, #70
    BLT addSpace
    CMP R5, #75
    BLT startDraw
    CMP R5, #80
    BLT addSpace
    CMP R5, #85
    BLT startDraw
    CMP R5, #90
    BLT addSpace
    CMP R5, #95
    BLT startDraw
    CMP R5, #100
    BLT addSpace

// adds a space in the middle of the matchsticks
addSpace:
    ADD R6, R6, #8
    B startDraw

// updates matchstick pos until it reaches correct column
setPos:
    ADD R6, R6, #24 // move matchstick 1 column over
    ADD R5, R5, #1 // update matchstick id
    B checkPos

// draws the matchstick
startDraw:
    ADD R7, R6, #256 // set second pixel pos
    ADD R8, R7, #256 // set third pixel pos
    STR R1, [R0, R6] // draw first pixel
    STR R2, [R0, R7] // draw second pixel
    STR R2, [R0, R8] // draw third pixel
    RET

// function clears screen
clearScreen:
    MOV R0, #.PixelScreen
    MOV R1, #0xffffff // white background colour
    MOV R2, #0 // number of cleared matchsticks
    MOV R3, #268 // set pos to first matchstick pos
clearLoop:
    // add space if cases:
    CMP R2, #5
    BEQ addSpace2
    CMP R2, #15
    BEQ addSpace2
    CMP R2, #25
    BEQ addSpace2
    CMP R2, #35
    BEQ addSpace2
    CMP R2, #45
    BEQ addSpace2
    CMP R2, #55
    BEQ addSpace2
    CMP R2, #65
    BEQ addSpace2
    CMP R2, #75
    BEQ addSpace2
    CMP R2, #85
    BEQ addSpace2
    CMP R2, #95
    BEQ addSpace2

    // clearing the matchsticks
clearStick:
    ADD R4, R3, #256 // set second pixel pos
    ADD R5, R4, #256 // set third pixel pos
    STR R1, [R0, R3] // clear first matchstick pixel
    STR R1, [R0, R4] // clear second matchstick pixel
    STR R1, [R0, R5] // clear third matchstick pixel
    ADD R3, R3, #24 // set next matchstick pos
    ADD R2, R2, #1 // update number of cleared matchsticks
    // new line if cases:
    CMP R2, #10
    BEQ nextRow
    CMP R2, #20
    BEQ nextRow
    CMP R2, #30
    BEQ nextRow
    CMP R2, #40
    BEQ nextRow
    CMP R2, #50
    BEQ nextRow
    CMP R2, #60
    BEQ nextRow
    CMP R2, #70
    BEQ nextRow
    CMP R2, #80
    BEQ nextRow
    CMP R2, #90
    BEQ nextRow
    CMP R2, #100
    BEQ endClearLoop
    B clearLoop
addSpace2:
    ADD R3, R3, #8
    B clearStick
nextRow:
    ADD R3, R3, #776 // sets pos to start of next line
    B clearLoop
endClearLoop: // ends the loop
    RET

// function asks if player wants to play again
playAgain:
    // checks if game is over
    CMP R3, #1
    BGT gameNotDone

    MOV R0, #gameMsg10 // "Would you like to play again? (Y/N) "
    STR R0, .WriteString
    MOV R1, #playAgainAnswer
    STR R1, .ReadString
    STR R1, .WriteString
    LDRB R2, [R1] // read ASCII value of R1
    ; if 'y' or 'Y', return to start of game
    CMP R2, #121 // 121 = 'y'
    BEQ continueTrue
    CMP R2, #89 // 89 = 'Y'
    BEQ continueTrue
    ; if 'n' or 'N', finish game
    CMP R2, #110 // 110 = 'n'
    BEQ continueFalse
    CMP R2, #78 // 78 = 'N'
    BEQ continueFalse
    MOV R0, #errorMsg2 // "Please enter 'y' or 'n'"
    STR R0, .WriteString
    B playAgain

// pass continue game value
gameNotDone:
    MOV R0, #0
    RET

// pass new game value
continueTrue:
    MOV R0, #1
    RET

// pass end game value
continueFalse:
    MOV R0, #2
    RET

// function prints win message to display
gameWin:
    MOV R0, #gameMsg8 // ", YOU WIN"
    STR R0, .WriteString
    RET

// function prints lose message to display
gameLose:
    MOV R0, #gameMsg9 // ", YOU LOSE"
    STR R0, .WriteString
    RET

// function displays game over message
gameOver:
    MOV R1, R0 // stores current turn in R1
    MOV R0, #gameMsg1 // "Player "
    STR R0, .WriteString
    STR R2, .WriteString // "{player name}"
    CMP R1, #0
    PUSH {LR, R0}
    BEQ gameWin
    POP {LR, R0}
    CMP R1, #1
    PUSH {LR, R0}
    BEQ gameLose
    POP {LR, R0}
    RET

// function displays game over message to display
gameDraw:
    MOV R0, #gameMsg7 // "It's a draw!"
    STR R0, .WriteString
    RET

// function removes selected matchsticks and updates matchstick number
gameUpdate:
    SUB R3, R3, R1 // removes selected matchsticks
    PUSH {LR, R0}
    CMP R3, #0 // checks if matchsticks left
    BEQ gameDraw
    POP {LR, R0}
    CMP R3, #1
    PUSH {LR, R0, R1}
    BEQ gameOver
    POP {LR, R0, R1}
    RET

// function handles computer turn
compTurn:
    MOV R0, #gameMsg5 // "Computer Player's turn."
    STR R0, .WriteString
retry3:
    LDR R0, .Random
    AND R0, R0, #7 // converts random number to 0-7
    CMP R0, #0 // checks if random number = 0
    BEQ retry3 // generates new random number if it = 0
    CMP R0, R3 // compares random number to matchstick number
    BGT retry3 // generates new random number if its bigger than matchstick number
    STR R0, .WriteUnsignedNum
    MOV R2, #gameMsg6 // " matchsticks were removed."
    STR R2, .WriteString
    MOV R1, #1 // store computer turn
    RET

// function handles player turn
retry2:
    MOV R0, #errorMsg1 // "Please enter a valid number."
    STR R0, .WriteString
playerTurn:
    MOV R0, #gameMsg1 // "Player "
    STR R0, .WriteString
    STR R2, .WriteString // "{player name}"
    MOV R0, #gameMsg4 // ", how many do you want to remove (1-7)? "
    STR R0, .WriteString
    LDR R0, .InputNum // save removed matchsticks number to R1
    STR R0, .WriteUnsignedNum
    CMP R0, R3
    BGT retry2
    CMP R0, #1
    BLT retry2
    CMP R0, #7
    BGT retry2
    MOV R1, #0 // store player turn
    RET

// function prints message of matchsticks left in the game to player
gameMessage:
    MOV R0, #gameMsg1 // "Player "
    STR R0, .WriteString
    STR R2, .WriteString // "{player name}"
    MOV R0, #gameMsg2 // ", there are "
    STR R0, .WriteString
    STR R3, .WriteUnsignedNum // "{matchsticks number}"
    MOV R0, #gameMsg3 // " matchsticks remaining."
    STR R0, .WriteString
    RET

// function retrieves and stores player data
getGameInfo:
    PUSH {LR}
    BL getPlayerInfo
    POP {LR}
    PUSH {LR}
    BL getMatchstickInfo
    POP {LR}
    RET

// function retrieves and stores player info
getPlayerInfo:
    MOV R0, #getName // "Please enter your name: "
    STR R0, .WriteString
    MOV R2, #playerName
    STR R2, .ReadString // save player name to R5
    STR R2, .WriteString
    RET

// function retrieves and stores matchstick info
retry:
    MOV R1, #errorMsg1 // "Please enter a valid number."
    STR R1, .WriteString
getMatchstickInfo:
    MOV R0, #getMatchsticks // "How many matchsticks (10-100)? "
    STR R0, .WriteString
    LDR R3, .InputNum // save matchstick number to R3
    STR R3, .WriteUnsignedNum
    CMP R3, #10
    BLT retry
    CMP R3, #100
    BGT retry
    RET

// function prints player and matchstick info to display
writeGameInfo:
    PUSH {LR}
    BL writePlayerInfo
    POP {LR}
    PUSH {LR}
    BL writeMatchstickInfo
    POP {LR}
    RET

// function prints player name to display
writePlayerInfo:
    MOV R0, #writePlayerMsg // "Player 1 is "
    STR R0, .WriteString
    STR R2, .WriteString // "{player name}"
    RET

// function prints matchstick number to display
writeMatchstickInfo:
    MOV R0, #writeMatchsticksMsg // "How many matchsticks (10-100)? "
    STR R0, .WriteString
    STR R3, .WriteUnsignedNum // "{matchsticks number}"
    RET

; * * * * * * * * * * * * * * * * * * * * *
.Align 256
getName: .ASCIZ "\nPlease enter your name: "
getMatchsticks: .ASCIZ "\nHow many matchsticks (10-100)? " 
writePlayerMsg: .ASCIZ "\nPlayer 1 is "
writeMatchsticksMsg: .ASCIZ "\nMatchsticks: "
gameMsg1: .ASCIZ "\nPlayer "
gameMsg2: .ASCIZ ", there are "
gameMsg3: .ASCIZ " matchsticks remaining."
gameMsg4: .ASCIZ ", how many do you want to remove (1-7)? "
gameMsg5: .ASCIZ "\n\nComputer Player's turn.\n"
gameMsg6: .ASCIZ " matchsticks were removed."
gameMsg7: .ASCIZ "\nIt's a draw!"
gameMsg8: .ASCIZ ", YOU WIN!"
gameMsg9: .ASCIZ ", YOU LOSE!"
gameMsg10: .ASCIZ "\nWould you like to play again (y/n)? "
errorMsg1: .ASCIZ "\nPlease enter a valid number."
errorMsg2: .ASCIZ "\nPlease enter either 'y' or 'n'."
playerName: .BLOCK 20
playAgainAnswer: .BLOCK 1