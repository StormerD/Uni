; * * * * * * * * * * * * * * 
; Stage: 4
; Student Name: Dylan Rodwell
; Student Number: 105341089
; * * * * * * * * * * * * * * 
; R0 = stores notifications                             - stores pixel screen
; R1 = used to print message stored in R0               - stores position for matchstick pixel 1
; R2 = stores matchsticks removed every round           - stores position for matchstick pixel 2
; R3 = stores current turn (0 = player, 1 = computer)   - stores position for matchstick pixel 3
; R4 = stores y/n answer
; R5 = saves ASCII code of answer in R4
; R5 and R6 = stores pixel colour codes
; R7 = stores count currently drawn matchsticks
; R8 = stores player name                               - stores current matchstick id being drawn
; R9 = stores matchsticks number
; * * * * * * * * * * * * * * 

; 256   = 1 line
; 1024  = 4 lines
; 240   = bits we have to work with
; 60    = pixels we have to work with
; 10 matchsticks per line
; 10 lines

// initializes all functions to operare game
MatchsticksGame:
    BL getGameInfo // retrieves game data
    BL writeGameInfo // prints game data

gameFunctions:
    BL gameMessage // displays game state messages
    BL drawMatchstick // draws matchsticks
    BL playerTurn // handles player turn
    BL gameUpdate // updates game state
    BL clearScreen // clears screen
    BL drawMatchstick // draws matchsticks
    BL compTurn // handles computer turn
;    BL clearScreen // clears screen
    BL drawMatchstick // draws matchsticks
    BL gameUpdate // updates game state

gameContinue:
;    BL clearScreen // clears screen
    BL checkContinue // loops game if not over

finish:
;    BL clearScreen // clears screen
    HALT

// function draws current amount of matchsticks
drawMatchstick:
    PUSH {LR, R7}
    MOV R7, #0
redraw:
    BL drawSingleMatchstick
    ADD R7, R7, #1
    CMP R7, R9
    BNE redraw
    POP {LR, R7}
    RET

// function draws a single matchstick
drawSingleMatchstick:
    PUSH {LR, R0, R1, R2, R3, R5, R6, R8}
    MOV R0, #.PixelScreen
    MOV R5, #0xe21335 // top matchstick colour
    MOV R6, #0xc1a061 // bottom matchstick colour
    MOV R1, #264 // leave 1 line gap
    MOV R8, #0 // id of current matchstick

// sets position of pixel into defined row
setRow0:
    CMP R7, #9 // check if the current row is full
    BGT setRow1
    BL checkPos
setRow1:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    CMP R7, #19 // check if the current row is full
    BGT setRow2
    BL checkPos
setRow2:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    CMP R7, #29 // check if the current row is full
    BGT setRow3
    BL checkPos
setRow3:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    CMP R7, #39 // check if the current row is full
    BGT setRow4
    BL checkPos
setRow4:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    CMP R7, #49 // check if the current row is full
    BGT setRow5
    BL checkPos
setRow5:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    CMP R7, #59 // check if the current row is full
    BGT setRow6
    BL checkPos
setRow6:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    CMP R7, #69 // check if the current row is full
    BGT setRow7
    BL checkPos
setRow7:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    CMP R7, #79 // check if the current row is full
    BGT setRow8
    BL checkPos
setRow8:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    CMP R7, #89 // check if the current row is full
    BGT setRow9
    BL checkPos
setRow9:
    ADD R8, R8, #10 // update matchstick id
    ADD R1, R1, #1024 // move pixel to new row
    BL checkPos

// function checks the matchstick position to see if it is in the right spot
checkPos:
    CMP R8, R7
    BNE setPos
    BL startDraw

// updates the position of the matchstick until it reaches the propper space in the row
setPos:
    ADD R1, R1, #24 // move matchstick along 1 space
    ADD R8, R8, #1 // update matchstick id
    B checkPos

// draws the matchstick
startDraw:
    ADD R2, R1, #256 // set second pixel position
    ADD R3, R2, #256 // set third pixel position
    STR R5, [R0, R1] // draw first matchstick pixel    - first colour
    STR R6, [R0, R2] // draw second matchstick pixel   - second colour
    STR R6, [R0, R3] // draw third matchstick pixel    - second colour
    POP {LR, R0, R1, R2, R3, R5, R6, R8}
    RET

// function clears the screen back to white
clearScreen:
    PUSH {LR, R0, R1, R2, R3, R4, R5}
    MOV R0, #.PixelScreen
    MOV R1, #264 // matchstick position
    MOV R4, #0 // number of wiped matchsticks
    MOV R5, #0xffffff // white background colour
clearLoop: // changes all matchstick pixels instead of every pixel to increase efficiency
    ADD R2, R1, #256 // set second pixel position
    ADD R3, R2, #256 // set third pixel position
    STR R5, [R0, R1] // clear first matchstick pixel    - white colour
    STR R5, [R0, R2] // draw second matchstick pixel   - white colour
    STR R5, [R0, R3] // draw third matchstick pixel    - white colour
    ADD R1, R1, #24
    ADD R4, R4, #1
    CMP R4, #10
    BEQ nextRow
    CMP R4, #20
    BEQ nextRow
    CMP R4, #30
    BEQ nextRow
    CMP R4, #40
    BEQ nextRow
    CMP R4, #50
    BEQ nextRow
    CMP R4, #60
    BEQ nextRow
    CMP R4, #70
    BEQ nextRow
    CMP R4, #80
    BEQ nextRow
    CMP R4, #90
    BEQ nextRow
    CMP R4, #100
    BEQ endClearLoop
    B clearLoop
nextRow:
    ADD R1, R1, #784
    BL clearLoop
endClearLoop: // ends the loop
    POP {LR, R0, R1, R2, R3, R4, R5}
    RET


// function checks if the game is not over and loops it back
checkContinue:
    PUSH {LR, R0}
    CMP R9, #1 // checks if game is over
    BGT gameFunctions
    BL playAgain
    POP {LR, R0}
    RET

// function asks if player wants to play again
playAgain:
    PUSH {LR, R0, R4, R5}
    MOV R0, #gameMsg10 // "Would you like to play again (y/n)?"
    BL displayMessage
    MOV R4, #playAgainAnswer
    STR R4, .ReadString
    LDRB R5, [R4]
    ; if 'y' or 'Y', return to start of game
    CMP R5, #121 // 121 = 'y'
    BEQ MatchsticksGame
    CMP R5, #89 // 89 = 'Y'
    BEQ MatchsticksGame
    ; if 'n' or 'N', finish game
    CMP R5, #110 // 110 = 'n'
    BEQ finish
    CMP R5, #78 // 78 = 'N'
    BEQ finish
    MOV R0, #errorMsg2 // "Please enter 'y' or 'n'"
    BL displayMessage
    B playAgain
    POP {LR, R0, R4, R5}

// function prints draw message
gameDraw:
    PUSH {LR, R0}
    MOV R0, #gameMsg7 // "It's a draw!"
    BL displayMessage
    BL gameContinue
    POP {LR, R0}

// function prints win message
gameWin:
    PUSH {LR, R0}
    MOV R0, #gameMsg8 // ", YOU WIN!"
    BL displayMessage
    BL gameContinue
    POP {LR, R0}

// function prints lose message
gameLose:
    PUSH {LR, R0}
    MOV R0, #gameMsg9 // ", YOU LOSE!"
    BL displayMessage
    BL gameContinue
    POP {LR, R0}

// function checks who won
gameOver:
    PUSH {LR, R0, R3, R8}
    MOV R0, #gameMsg1 // "Player "
    BL displayMessage
    STR R8, .WriteString // "{player name}"
    CMP R3, #0
    BEQ gameWin
    CMP R3, #1
    BEQ gameLose
    POP {LR, R0, R3, R8}
    RET

// function removes selected matchsticks and updates matchstick number
gameUpdate:
    PUSH {LR, R0}
    SUB R9, R9, R2 // removes selected matchsticks
    CMP R9, #0 // checks if matchsticks left
    BEQ gameDraw
    CMP R9, #1
    BEQ gameOver
    POP {LR, R0}
    RET

// function handles computer turn
compTurn:
    PUSH {LR, R0, R9}
    MOV R0, #gameMsg5 // "Computer Player's turn"
    BL displayMessage
retry3:
    LDR R2, .Random
    AND R2, R2, #7 // converts random number to 0-7
    CMP R2, #0
    BEQ retry3
    CMP R2, R9
    BGT retry3
    STR R2, .WriteUnsignedNum
    MOV R0, #gameMsg6 // " matchsticks were removed"
    BL displayMessage
    MOV R3, #1 // store computers turn
    POP {LR, R0, R9}
    RET

// function handles player turn
playerTurn:
    PUSH {LR, R0}
    BL continue2
retry2:
    MOV R0, #errorMsg1 // "Please enter a valid number."
    BL displayMessage
continue2:
    MOV R0, #gameMsg1 // "Player "
    BL displayMessage
    STR R8, .WriteString // "{player name}"
    MOV R0, #gameMsg4 // ", how many do you want to remove (1-7)?"
    BL displayMessage
    LDR R2, .InputNum // save removed matchsticks value to R2
    STR R2, .WriteUnsignedNum
    CMP R2, R9
    BGT retry2
    CMP R2, #1
    BLT retry2
    CMP R2, #7
    BGT retry2
    MOV R3, #0 // store players turn
    POP {LR, R0}
    RET

// function prints message of matchsticks left in the game to player
gameMessage:
    PUSH {LR, R0}
    MOV R0, #gameMsg1 // "Player "
    BL displayMessage
    STR R8, .WriteString // "{player name}"
    MOV R0, #gameMsg2 // ", there are "
    BL displayMessage
    STR R9, .WriteUnsignedNum // "{matchsticks left}"
    MOV R0, #gameMsg3 // " matchsticks remaining."
    BL displayMessage
    POP {LR, R0}
    RET

// function retrieves and stores player and matchstick info
getGameInfo:
    PUSH {LR}
    BL getPlayerInfo
    BL getMatchstickInfo
    POP {LR}
    RET

// function retrieves and stores player info
getPlayerInfo:
    PUSH {LR, R0}
    MOV R0, #getName // "Please enter your name: "
    BL displayMessage
    MOV R8, #playerName
    STR R8, .ReadString // save player name to R8
    STR R8, .WriteString
    POP {LR, R0}
    RET

// function retrieves and stores matchstick info
getMatchstickInfo:
    PUSH {LR, R0}
    BL continue1
retry1:
    MOV R0, #errorMsg1 // "Please enter a valid number."
    BL displayMessage
continue1:
    MOV R0, #getMatchsticks // "How many matchsticks (10-100)? "
    BL displayMessage
    LDR R9, .InputNum // save matchstick number to R9
    STR R9, .WriteUnsignedNum
    CMP R9, #10
    BLT retry1
    CMP R9, #100
    BGT retry1
    POP {LR, R0}
    RET

// function prints player and matchstick info
writeGameInfo:
    PUSH {LR}
    BL writePlayerInfo
    BL writeMatchstickInfo
    POP {LR}
    RET

// function prints player name
writePlayerInfo: 
    PUSH {LR, R0, R8}
    MOV R0, #writePlayerMsg
    BL displayMessage
    STR R8, .WriteString
    POP {LR, R0, R8}
    RET

// function prints matchstick number
writeMatchstickInfo:
    PUSH {LR, R0, R9}
    MOV R0, #writeMatchsticksMsg
    BL displayMessage
    STR R9, .WriteUnsignedNum
    POP {LR, R0, R9}
    RET

// function prints messages stored to R0
displayMessage:
    MOV R1, R0
    STR R1, .WriteString
    RET

; - - - - - - - - -
.Align 256
getName: .ASCIZ "Please enter your name: "
getMatchsticks: .ASCIZ "\nHow many matchsticks (10-100)? " 
writePlayerMsg: .ASCIZ "\nPlayer 1 is "
writeMatchsticksMsg: .ASCIZ "\nMatchsticks: "
gameMsg1: .ASCIZ "\nPlayer "
gameMsg2: .ASCIZ ", there are "
gameMsg3: .ASCIZ " matchsticks remaining."
gameMsg4: .ASCIZ ", how many do you want to remove (1-7)? "
gameMsg5: .ASCIZ "\nComputer Player's turn\n"
gameMsg6: .ASCIZ " matchsticks were removed"
gameMsg7: .ASCIZ "\nIt's a draw!"
gameMsg8: .ASCIZ ", YOU WIN!"
gameMsg9: .ASCIZ ", YOU LOSE!"
gameMsg10: .ASCIZ "\nWould you like to play again (y/n)? "
errorMsg1: .ASCIZ "\nPlease enter a valid number."
errorMsg2: .ASCIZ "\nPlease enter either 'y' or 'n'."
playerName: .BLOCK 20
playAgainAnswer: .BLOCK 1