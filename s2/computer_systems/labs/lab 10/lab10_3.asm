  1|Flash:
  2|      mov r0, #1        ; delay time (s)
  3|      mov r1, #2        ; pause time (s)
  4|      bl FlashPattern   ; FlashPattern
  5|      bl FlashPattern   ; FlashPattern
  6|      push {r0}
  7|      mov r0, r1
  8|      bl FlashPattern   ; FlashPattern
  9|      pop {r0}
 10|      halt
 11|FlashPattern:
 12|      push {lr}
 13|      mov r2, #.green   ; flash on
 14|      bl DrawPixel      ; draws pixel
 15|      mov r2, #.white   ; flash off
 16|      bl DrawPixel      ; draws pixel
 17|      pop {lr}
 18|      ret               ; return to Flash
 19|DrawPixel:
 20|      str r2, .Pixel367 ; flash on
 21|      push {lr}
 22|      bl Delay          ; Delay function
 23|      pop {lr}
 24|      ret               ; returns to Flash
 25|Delay:
 26|      ldr r3, .Time     ; set up time when start the function
 27|Time:                   ; current time in loop
 28|      ldr r4, .Time     ; set up current time in loop
 29|      sub r5, r4, r3    ; subtract start time from current time to find time passed
 30|      cmp r5, r0        ; compare time passed to start time
 31|      bne Time          ; if branch is not equal go to time
 32|      ret               ; returns to DrawPixel function