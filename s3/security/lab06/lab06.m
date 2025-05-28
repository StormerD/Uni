ct1 = [11 34 57 51 39 32 21 38 51 23 35 34 34 51 41 17];
ct2 = [41 24 44 17 20 4 38 55 36 50 4 55 11 23 16 55];
ct3 = [14 33 11 53 51 17 11 4 51 30 39 4 49 2 54 34];
ct4 = [42 9 26 17 38 34 44 44 21 45 20 39 36 49 33 10];
ct5 = [59 43 62 34 4 6 4 5 54 7 59 20 12 18 26 57];
ct6 = [31 8 13 52 43 32 17 20 18 53 8 61 4 52 63 10];
ct7 = [8 29 62 45 62 55 57 54 52 6 33 40 55 7 12 57];
cts = {ct1, ct2, ct3, ct4, ct5, ct6, ct7};

key = 10; % Found key

plaintext = strings(7, 1);
plaintext(1) = decrypt(ct1, key);
for i = 2:7
    input_block = bitxor(cts{i}, cts{i-1});
    plaintext(i) = decrypt(input_block, key);
end

disp('Recovered plaintext:');
for i = 1:7
    disp(plaintext(i));
end
