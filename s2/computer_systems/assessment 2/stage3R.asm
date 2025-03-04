; * * * * * * * * * * * * * * 
; Stage: 3
; Student Name: Dylan Rodwell
; Student Number: 105341089
; * * * * * * * * * * * * * * 
; R0 = stores notifications
; R1 = used to print message stored in R0
; R2 = stores matchsticks removed every round
; R3 = stores current turn (0 = player, 1 = computer)
; R4 = stores y/n answer
; R5 = saves ASCII code of answer in R4
; R6 = stores player name
; R7 = stores matchsticks number
; * * * * * * * * * * * * * * 

// initializes all functions to operare game
MatchsticksGame:
    BL getGameInfo // retrieves game data
    BL writeGameInfo // prints game data

gameFunctions:
    BL gameMessage // displays game state messages
    BL playerTurn // handles player turn
    BL gameUpdate // updates game state
    BL compTurn // handles computer turn
    BL gameUpdate // updates game state

gameContinue:
    BL checkContinue // loops game if not over

finish:
    HALT

// function checks if the game is not over and loops it back
checkContinue:
    PUSH {LR, R0}
    CMP R7, #1 // checks if game is over
    BGT gameFunctions
    BL playAgain
    POP {LR, R0}

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
    PUSH {LR, R0, R3, R6}
    MOV R0, #gameMsg1 // "Player "
    BL displayMessage
    STR R6, .WriteString // "{player name}"
    CMP R3, #0
    BEQ gameWin
    CMP R3, #1
    BEQ gameLose
    POP {LR, R0, R3, R6}
    RET

// function removes selected matchsticks and updates matchstick number
gameUpdate:
    PUSH {LR, R0}
    SUB R7, R7, R2 // removes selected matchsticks
    CMP R7, #0 // checks if matchsticks left
    BEQ gameDraw
    CMP R7, #1
    BEQ gameOver
    POP {LR, R0}
    RET

// function handles computer turn
compTurn:
    PUSH {LR, R0, R7}
    MOV R0, #gameMsg5 // "Computer Player's turn"
    BL displayMessage
retry3:
    LDR R2, .Random
    AND R2, R2, #7 // converts random number to 0-7
    CMP R2, #0
    BEQ retry3
    CMP R2, R7
    BGT retry3
    STR R2, .WriteUnsignedNum
    MOV R0, #gameMsg6 // " matchsticks were removed"
    BL displayMessage
    MOV R3, #1 // store computers turn
    POP {LR, R0, R7}
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
    STR R6, .WriteString // "{player name}"
    MOV R0, #gameMsg4 // ", how many do you want to remove (1-7)?"
    BL displayMessage
    LDR R2, .InputNum // save removed matchsticks value to R2
    STR R2, .WriteUnsignedNum
    CMP R2, R7
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
    STR R6, .WriteString // "{player name}"
    MOV R0, #gameMsg2 // ", there are "
    BL displayMessage
    STR R7, .WriteUnsignedNum // "{matchsticks left}"
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
    MOV R6, #playerName
    STR R6, .ReadString // save player name to R6
    STR R6, .WriteString
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
    LDR R7, .InputNum // save matchstick number to R7
    STR R7, .WriteUnsignedNum
    CMP R7, #10
    BLT retry1
    CMP R7, #100
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
    PUSH {LR, R0, R6}
    MOV R0, #writePlayerMsg
    BL displayMessage
    STR R6, .WriteString
    POP {LR, R0, R6}
    RET

// function prints matchstick number
writeMatchstickInfo:
    PUSH {LR, R0, R7}
    MOV R0, #writeMatchsticksMsg
    BL displayMessage
    STR R7, .WriteUnsignedNum
    POP {LR, R0, R7}
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