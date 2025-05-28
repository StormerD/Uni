% Dylan Rodwell
% 105341089
% 105341089@student.swin.edu.au

% - - Cypher 1 - -
% 1. Define public key [n, e].
n1 = 2407;
e1 = 57;

% 2. Define message to decrypt.
c1 = [2377 400 2296 640 1142 1770 2014 540 1188 1285 586 1421 1770 586 1142 2395 640 479 640 1205 2395 1770 586 1142 1770 1421 479 602 2014 2395 476 1019 479 1274 2014 2296 602 1770 194 1274 1205 1770 1950 540 1205 2395 1770 640 2011 640 479 1019 586 1142 1019 1770 586 1142 1770 2395 2296 640 1770 1285 1274 2395 640 1770 1205 640 1904 640 1142 2395 586 640 1205 1770 1274 1142 1741 1770 640 1274 479 1285 602 1770 640 586 1019 2296 2395 586 640 1205 174 1770 2395 2296 640 1770 1319 1274 2395 586 476 1142 1274 1285 1770 1295 640 1421 540 479 586 2395 602 1770 1 1019 640 1142 1421 602 1770 2011 1274 1741 640 1770 1205 640 1904 640 479 1274 1285 1770 1274 2395 2395 640 2011 2014 2395 1205 1770 2395 476 1770 1348 540 1274 1205 2296 1770 586 2395 1216];

% 3. Get secret primes (p, q).
factors = factor(n1);
p1 = factors(1);
q1 = factors(2);

% 4. Compute Euler's tutient.
x1 = (p1 - 1) * (q1 - 1);

% 5. Find private exponent (d), so (d*e) mod x == 1.
for d1 = 1:x1
    if mod(d1 * e1, x1) == 1
        break;
    end
end

% 6. Define presentation text string.
outputLabel = 'Message One:';

% 7. Call decrypt function.
m1 = decryptString(n1, d1, c1);


% 8. Display message.
disp(outputLabel)
disp(m1)



% - - Cypher 2 - -
% 1. Define public key [n, e].
n2 = 7663;
e2 = 89;

% 2. Define message to decrypt.
c2 = [4514 5363 2971 7198 1332 5465 2980 454 7130 1332 2682 4485 6069 5363 1332 6069 5363 7130 1332 1889 2957 2682 5943 2971 4580 1332 1889 5561 2980 4580 6069 2971 4580 7130 1332 4485 2178 1332 4580 5561 3243 1889 6069 4485 5465 5561 2980 1889 5363 3243 1332 5943 4485 6069 7198 1332 4485 2178 1332 2957 3647 7130 4900 1889 7130 4580 6069 7130 1145 1332 1889 2957 2682 5943 2971 4580 2971 6069 3243 656 7023 1332 5585 5363 2971 6069 2178 2971 7130 5943 1145 1332 431 2971 2178 2178 2971 7130 1332 2971 3647 1332 7023 1 1889 1889 5943 2971 7130 1145 1332 108 5561 3243 1889 6069 4485 5465 5561 2980 1889 5363 3243 3646 7023 656 1332 6689 2980 2682 5561 2971 1145 5465 7130 1145 1603];

% 3. Get secret primes (p, q).
factors = factor(n2);
p2 = factors(1);
q2 = factors(2);

% 4. Compute Euler's tutient.
x2 = (p2 - 1) * (q2 - 1);

% 5. Find private exponent (d), so (d*e) mod x == 1.
for d2 = 1:x2
    if mod(d2 * e2, x2) == 1
        break;
    end
end

% 6. Define presentation text string.
outputLabel = 'Message Two:';

% 7. Call decrypt function.
m2 = decryptString(n2, d2, c2);

% 8. Display message.
disp(outputLabel)
disp(m2)

% - - Both Messages Together - -
% 1. Define presentation text string.
outputLabel = 'Both Messages Together:';
disp(outputLabel);
disp([m1 ' ' m2]);