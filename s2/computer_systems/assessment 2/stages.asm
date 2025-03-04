; * * * * * * * * * * * * * * * * * * * * *
; Stage ?
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
    PUSH {LR, R0, R2, R3}
    BL getGameInfo // retrieves game data
    MOV R4, R2 // stores player name return value in R4
    MOV R5, R3 // stores matchsticks number return value in R5
    POP {LR, R0, R2, R3}

    PUSH {LR, R0, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL writeGameInfo // prints game data
    POP {LR, R0, R2, R3}

// functions that operate the game
gameFunctions:
    PUSH {LR, R0, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL gameMessage
    POP {LR, R0, R2, R3}

    PUSH {LR, R0, R1, R2, R3}
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL playerTurn
    MOV R6, R0 // stores removed matchsticks number in R6
    MOV R7, R1 // stores updated current turn in R7
    POP {LR, R0, R1, R2, R3}

    PUSH {LR, R0, R1, R2, R3}
    MOV R0, R7 // passes current turn via R0
    MOV R1, R6 // passes removed matchsticks number via R2
    MOV R2, R4 // passes player name via R2
    MOV R3, R5 // passes matchstick number via R3
    BL gameUpdate
    MOV R5, R3 // updates new matchsticks value in R5
    POP {LR, R0, R1, R2, R3}

    // checks if game is over
    PUSH {LR, R3}
    MOV R3, R5 // passes matchstick number via R3
    checkContinue
    POP {LR, R3}
    
    CMP R5, #2
    PUSH {LR, R0, R1, R2, R3}
    BLT playAgain
    CMP R3, #1
    POP {LR, R0, R1, R2, R3}
    BEQ finish
    B gameFunctions
    
// function ends the program
finish:
    HALT

// function checks if the game will continue or not
checkContinue:
    CMP R3, #2
    POP {R3}
    BLT playAgain
    B gameFunctions

// function asks if player wants to play again
playAgain:
    MOV R0, #gameMsg10 // "Would you like to play again? (Y/N) "
    STR R0, .WriteString
    MOV R1, #playAgainAnswer
    STR R1, .ReadString
    STR R1, .WriteString
    LDRB R2, [R1] // read ASCII value of R1
    ; if 'y' or 'Y', return to start of game
    CMP R2, #121 // 121 = 'y'
    PUSH {LR}
    BEQ continueTrue
    POP {LR}
    CMP R2, #89 // 89 = 'Y'
    PUSH {LR}
    BEQ continueTrue
    POP {LR}
    ; if 'n' or 'N', finish game
    CMP R2, #110 // 110 = 'n'
    PUSH {LR}
    BEQ continueFalse
    POP {LR}
    CMP R2, #78 // 78 = 'N'
    PUSH {LR}
    BEQ continueFalse
    POP {LR}
    MOV R0, #errorMsg2 // "Please enter 'y' or 'n'"
    STR R0, .WriteString
    B playAgain

continueTrue:
    MOV R3, #0
    RET

continueFalse:
    MOV R3, #1
    RET

// function prints win message to display
gameWin:
    MOV R0, #gameMsg8 // ", YOU WIN"
    STR R0, .WriteString
    RET

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

gameDraw:
    MOV R0, #gameMsg7 // "It's a draw!"
    RET

// function removes selected matchsticks and updates matchstick number
gameUpdate:
    SUB R3, R3, R1 // removes selected matchsticks
    CMP R3, #0 // checks if matchsticks left
    PUSH {LR, R0}
    BEQ gameDraw
    POP {LR, R0}
    CMP R3, #1
    PUSH {LR, R0, R1}
    BEQ gameOver
    POP {LR, R0, R1}
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
    MOV R1, #0
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
getName: .ASCIZ "Please enter your name: "
getMatchsticks: .ASCIZ "\nHow many matchsticks (10-100)? " 
writePlayerMsg: .ASCIZ "\nPlayer 1 is "
writeMatchsticksMsg: .ASCIZ "\nMatchsticks: "
gameMsg1: .ASCIZ "\nPlayer "
gameMsg2: .ASCIZ ", there are "
gameMsg3: .ASCIZ " matchsticks remaining."
gameMsg4: .ASCIZ ", how many do you want to remove (1-7)? "
gameMsg5: .ASCIZ "\nGame Over!"
gameMsg6: .ASCIZ " matchsticks were removed"
gameMsg7: .ASCIZ "\nIt's a draw!"
gameMsg8: .ASCIZ ", YOU WIN!"
gameMsg9: .ASCIZ ", YOU LOSE!"
gameMsg10: .ASCIZ "\nWould you like to play again (y/n)? "
errorMsg1: .ASCIZ "\nPlease enter a valid number."
errorMsg2: .ASCIZ "\nPlease enter either 'y' or 'n'."
playerName: .BLOCK 20
playAgainAnswer: .BLOCK 1