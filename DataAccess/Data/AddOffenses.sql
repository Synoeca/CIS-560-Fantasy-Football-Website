USE Team13;
GO

INSERT INTO Football.Offense(PlayerID, GameID, PassingYards, PassingAttempts, RushingYards, Carries, ReceivingYards, Receptions, Touchdowns)
VALUES 
    
 -- Arizona at Kansas State Offense
 -- Arizona
 (4, 1, 268, 42, 5, 3, 0, 0, 0), -- Noah Fifita
 (7, 1, 0, 0, 48, 14, 2, 1, 1), -- Quali Conley
 (12, 1, 0, 0, 3, 2, 14, 2, 0), -- Kedrick Reescano
 (23, 1, 0, 0, 0, 0, 138, 11, 0), -- Tetairoa McMillan
 (21, 1, 0, 0, 0, 0, 75, 6, 0), -- Montana Lemonious-Craig
 (11, 1, 0, 0, 0, 0, 19, 2, 0), -- Rayshon Luke
 (18, 1, 0, 0, 0, 0, 12, 1, 0), -- Chris Hunter
 (19, 1, 0, 0, 0, 0, 6, 1, 0), -- Devin Hyatt
 (32, 1, 0, 0, 0, 0, 5, 1, 0), -- Sam Olson
 (28, 1, 0, 0, 0, 0, 0, 0, 0), -- Malachi Riley
 (29, 1, 0, 0, 0, 0, 0, 0, 0), -- Keyan Burnett
 (26, 1, 0, 0, 0, 0, -3, 1, 0), -- Jeremiah Patterson

 -- Kansas State
 (519, 1, 156, 23, 110, 17, 0, 0, 2), -- Avery Johnson
 (524, 1, 0, 0, 86, 17, 0, 0, 1), -- DJ Giddens
 (523, 1, 0, 0, 41, 6, 3, 1, 0), -- Dylan Edwards
 (530, 1, 0, 0, 0, 0, 60, 3, 0), -- Jayce Brown
 (548, 1, 0, 0, 0, 0, 45, 3, 1), -- Brayden Loftin
 (535, 1, 0, 0, 0, 0, 22, 2, 0), -- Keagan Johnson
 (531, 1, 0, 0, 0, 0, 9, 1, 0), -- Dante Cephas
 (534, 1, 0, 0, 0, 0, 8, 1, 0), -- Jadon Jackson
 (552, 1, 0, 0, 0, 0, 6, 2, 1), -- Will Swanson
 (542, 1, 0, 0, 0, 0, 3, 1, 0), -- Tre Spivey

 -- UCF at TCU Offense
 -- UCF
 (873, 2, 230, 22, 46, 9, 0, 0, 3), -- KJ Jefferson
 (879, 2, 0, 0, 180, 29, 29, 1, 3), -- RJ Harvey
 (876, 2, 0, 0, 24, 7, 0, 0, 0), -- Peny Boone
 (895, 2, 0, 0, 19, 4, -2, 2, 0), -- Xavier Townsend
 (881, 2, 0, 0, 13, 3, 0, 0, 0), -- Myles Montgomery
 (882, 2, 0, 0, 7, 2, 0, 0, 0), -- Johnny Richardson
 (887, 2, 0, 0, 0, 0, 145, 6, 2), -- Kobe Hudson
 (902, 2, 0, 0, 0, 0, 43, 3, 0), -- Randy Pittman Jr.
 (889, 2, 0, 0, 0, 0, 15, 1, 0), -- Jacoby Jones

 -- TCU
 (731, 2, 402, 52, 10, 1, 0, 0, 4), -- Josh Hoover
 (738, 2, 0, 0, 35, 11, 8, 4, 0), -- Cam Cook
 (740, 2, 0, 0, 14, 2, 0, 0, 0), -- Dominique Johnson
 (764, 2, 0, 0, 2, 1, 37, 4, 2), -- Savion Williams
 (742, 2, 0, 0, 1, 1, 21, 1, 0), -- Jeremy Payne
 (747, 2, 0, 0, 0, 0, 200, 9, 1), -- Jack Bech
 (759, 2, 0, 0, 0, 0, 54, 4, 1), -- Eric McAlister
 (761, 2, 0, 0, 0, 0, 46, 5, 0), -- JP Richardson
 (767, 2, 0, 0, 0, 0, 15, 3, 0), -- Drake Dabney
 (766, 2, 0, 0, 0, 0, 14, 3, 0), -- Chase Curtis
 (751, 2, 0, 0, 0, 0, 7, 2, 0), -- JoJo Earle

 -- Kansas at West Virginia Offense
 -- Kansas
 (586, 3, 184, 25, 11, 7, 0, 0, 1), -- Jalon Daniels
 (595, 3, 0, 0, 110, 27, 2, 1, 1), -- Devin Neal
 (603, 3, 0, 0, 55, 3, 75, 6, 2), -- Luke Grimm
 (599, 3, 0, 0, 0, 0, 46, 2, 0), -- Lawrence Arnold
 (615, 3, 0, 0, 0, 0, 25, 2, 0), -- Jared Casey
 (611, 3, 0, 0, 0, 0, 22, 2, 0), -- Quentin Skinner
 (620, 3, 0, 0, 0, 0, 9, 1, 0), -- Trevor Kardell

 -- West Virginia
 (1005, 3, 295, 30, 87, 17, 0, 0, 3), -- Garrett Greene
 (1012, 3, 0, 0, 38, 6, 0, 0, 0), -- CJ Donaldson Jr.
 (1016, 3, 0, 0, 15, 6, 16, 2, 1), -- Jahiem White
 (1026, 3, 0, 0, 12, 2, 41, 2, 1), -- Rodney Gallagher III
 (1007, 3, 0, 0, -3, 1, 0, 0, 0), -- Nicco Marchiol
 (1019, 3, 0, 0, 0, 0, 150, 7, 0), -- Hudson Clement
 (1029, 3, 0, 0, 0, 0, 70, 2, 0), -- Traylon Ray
 (1038, 3, 0, 0, 0, 0, 18, 2, 1), -- Kole Taylor
 (1018, 3, 0, 0, 0, 0, 0, 0, 0), -- Jaden Bray
 (1032, 3, 0, 0, 0, 0, 0, 0, 0), -- Jarel Williams

 -- Houston at Cincinnati Offense
 -- Houston
 (375, 4, 73, 16, 27, 9, 0, 0, 0), -- Donovan Smith
 (372, 4, 19, 5, 34, 9, 0, 0, 0), -- Zeon Chriss
 (383, 4, 0, 0, 62, 6, 23, 2, 0), -- Re'Shaun Sanford II
 (385, 4, 0, 0, 20, 6, 12, 2, 0), -- Stacy Sneed
 (380, 4, 0, 0, 5, 3, -1, 1, 0), -- Parker Jenkins
 (393, 4, 0, 0, 0, 0, 51, 2, 0), -- Joseph Manjack IV
 (406, 4, 0, 0, 0, 0, 5, 2, 0), -- Maliq Carr
 (394, 4, 0, 0, 0, 0, 3, 1, 0), -- Mekhi Mews
 (402, 4, 0, 0, 0, 0, 0, 1, 0), -- Jonah Wilson
 (392, 4, 0, 0, 0, 0, -1, 2, 0), -- Stephon Johnson

 -- Cincinnati
 (255, 4, 188, 15, 4, 3, 0, 0, 3), -- Brendan Sorsby
 (254, 4, 25, 4, -2, 4, 0, 0, 0), -- Brady Lichtenberg
 (261, 4, 0, 0, 78, 16, 19, 2, 1), -- Corey Kiner
 (263, 4, 0, 0, 38, 4, 0, 0, 0), -- Chance Williams
 (258, 4, 0, 0, 17, 3, 0, 0, 0), -- Manny Covey
 (262, 4, 0, 0, 8, 3, 0, 0, 0), -- Evan Pryor
 (259, 4, 0, 0, 8, 3, 0, 0, 0), -- Victor Dawson
 (265, 4, 0, 0, 0, 0, 60, 3, 0), -- Sterling Berkhalter
 (266, 4, 0, 0, 0, 0, 34, 2, 2), -- Xzavier Henderson
 (280, 4, 0, 0, 0, 0, 31, 2, 0), -- Joe Royer
 (271, 4, 0, 0, 0, 0, 20, 1, 0), -- Jamoi Mayes
 (268, 4, 0, 0, 0, 0, 17, 1, 0), -- Tony Johnson
 (274, 4, 0, 0, 0, 0, 10, 1, 0), -- Tyrin Smith
 (277, 4, 0, 0, 0, 0, 10, 1, 0), -- Joey Beljan
 (283, 4, 0, 0, 0, 0, 7, 1, 0), -- Devyn Zahursky
 (267, 4, 0, 0, 0, 0, 5, 1, 0), -- Barry Jackson Jr.

 -- Arizona State at Texas Tech Offense
 -- Arizona State
 (66, 5, 282, 38, 25, 9, 0, 0, 1), -- Sam Leavitt
 (73, 5, 0, 0, 60, 18, 117, 6, 2), -- Cam Skattebo
 (69, 5, 0, 0, 9, 3, 23, 3, 0), -- Kyson Brown
 (79, 5, 0, 0, 0, 0, 74, 6, 0), -- Xavier Guillory
 (87, 5, 0, 0, 0, 0, 33, 2, 0), -- Jordyn Tyson
 (95, 5, 0, 0, 0, 0, 22, 3, 0), -- Chamon Metayer
 (86, 5, 0, 0, 0, 0, 13, 2, 0), -- Melquan Stovall
 (84, 5, 0, 0, 0, 0, 0, 0, 0), -- Jake Smith
 (81, 5, 0, 0, 0, 0, 0, 0, 0), -- Malik McClain

 -- Texas Tech
 (807, 5, 201, 44, -15, 3, 0, 0, 2), -- Behren Morton
 (809, 5, 0, 0, 117, 27, 3, 2, 0), -- Tahj Brooks
 (810, 5, 0, 0, 24, 3, 0, 0, 0), -- Cameron Dickey
 (814, 5, 0, 0, 7, 2, 0, 0, 0), -- J'Koby Williams
 (833, 5, 0, 0, 3, 1, 0, 0, 1), -- Jalin Conyers
 (823, 5, 0, 0, 0, 0, 89, 10, 1), -- Josh Kelly
 (818, 5, 0, 0, 0, 0, 63, 5, 0), -- Caleb Douglas
 (819, 5, 0, 0, 0, 0, 29, 3, 0), -- Coy Eakin
 (839, 5, 0, 0, 0, 0, 12, 1, 0), -- Mason Tharp
 (837, 5, 0, 0, 0, 0, 5, 1, 1), -- Johncarlos Miller II
 (821, 5, 0, 0, 0, 0, 0, 1, 0), -- Micah Hudson
 (824, 5, 0, 0, 0, 0, 0, 1, 0), -- Drae McCray

 -- Utah at Oklahoma State Offense
 -- Utah
 (938, 6, 207, 29, 41, 6, 0, 0, 1), -- Isaac Wilson
 (940, 6, 0, 0, 182, 25, -2, 2, 0), -- Micah Bernard
 (946, 6, 0, 0, 10, 4, 5, 1, 0), -- Charlie Vincent
 (943, 6, 0, 0, 9, 8, 0, 0, 0), -- Mike Mitchell
 (945, 6, 0, 0, 7, 5, 0, 0, 0), -- Dijon Stanley
 (971, 6, 0, 0, 1, 1, 74, 4, 2), -- Brant Kuithe
 (961, 6, 0, 0, 0, 0, 95, 7, 0), -- Dorian Singer
 (958, 6, 0, 0, 0, 0, 35, 3, 0), -- Money Parks
 (965, 6, 0, 0, 0, 0, 0, 0, 0), -- Dallen Bentley

 -- Oklahoma State
 (652, 6, 206, 33, -8, 1, 0, 0, 2), -- Alan Bowman
 (654, 6, 31, 11, 0, 1, 0, 0, 0), -- Garret Rangel
 (660, 6, 0, 0, 42, 11, 16, 3, 0), -- Ollie Gordon II
 (684, 6, 0, 0, 11, 1, 47, 4, 1), -- Brennan Presley
 (665, 6, 0, 0, 3, 1, 3, 1, 0), -- Sesi Vailahi
 (687, 6, 0, 0, 0, 0, 50, 3, 0), -- De'Zhaun Stribling
 (685, 6, 0, 0, 0, 0, 49, 3, 0), -- Talyn Shettron
 (681, 6, 0, 0, 0, 0, 42, 3, 1), -- Rashod Owens
 (675, 6, 0, 0, 0, 0, 30, 2, 0), -- Gavin Freeman
 (692, 6, 0, 0, 0, 0, 0, 0, 0), -- Tyler Foster

 -- Baylor at Colorado Offense
 -- Baylor
 (131, 7, 148, 21, 82, 9, 0, 0, 3), -- Sawyer Robertson
 (137, 7, 0, 0, 47, 15, 19, 1, 0), -- Dominic Richardson
 (138, 7, 0, 0, 21, 10, 14, 2, 0), -- Bryson Washington
 (135, 7, 0, 0, 13, 4, 0, 0, 0), -- Dawson Pendergrass
 (136, 7, 0, 0, 3, 2, 0, 0, 0), -- Richard Reese
 (140, 7, 0, 0, 0, 1, 36, 3, 1), -- Monaray Baldwin
 (151, 7, 0, 0, 0, 0, 43, 2, 1), -- Hal Presley
 (149, 7, 0, 0, 0, 0, 30, 2, 0), -- Ketron Jackson Jr.
 (144, 7, 0, 0, 0, 0, 6, 1, 0), -- Josh Cameron
 (157, 7, 0, 0, 0, 0, 0, 0, 0), -- Michael Trigg
 (148, 7, 0, 0, 0, 0, 0, 0, 0), -- Ashtyn Hawkins

 -- Colorado
 (312, 7, 341, 41, 26, 19, 0, 0, 3), -- Shedeur Sanders
 (316, 7, 0, 0, 41, 12, -3, 1, 0), -- Isaiah Augustave
 (322, 7, 0, 0, 22, 9, -1, 1, 2), -- Micah Welch
 (325, 7, 0, 0, 3, 1, 40, 4, 0), -- Jimmy Horn Jr.
 (326, 7, 0, 0, 0, 0, 130, 7, 0), -- Travis Hunter
 (331, 7, 0, 0, 0, 0, 71, 2, 1), -- Omarion Miller
 (338, 7, 0, 0, 0, 0, 68, 4, 1), -- LaJohntay Wester
 (330, 7, 0, 0, 0, 0, 27, 3, 0), -- Drelon Miller
 (334, 7, 0, 0, 0, 0, 5, 1, 0), -- Will Sheppard
 (343, 7, 0, 0, 0, 0, 5, 1, 0), -- Sav'ell Smalls
 (339, 7, 0, 0, 0, 0, -1, 1, 0), -- Sam Hart


 -- West Virginia at Oklahoma State Offense
 -- West Virginia
 (1005, 8, 159, 15, 86, 10, 0, 0, 1), -- Garrett Greene
 (1007, 8, 10, 1, 46, 7, 0, 0, 1), -- Nicco Marchiol
 (1016, 8, 0, 0, 158, 19, 0, 0, 1), -- Jahiem White
 (1012, 8, 0, 0, 77, 20, 0, 0, 2), -- CJ Donaldson Jr.
 (1009, 8, 0, 0, 19, 3, 0, 0, 0), -- Jaylen Anderson
 (1024, 8, 0, 0, 4, 1, 0, 0, 0), -- Ric'Darious Farmer
 (1014, 8, 0, 0, 1, 1, 0, 0, 0), -- Diore Hubbard
 (1026, 8, 0, 0, 0, 2, 12, 1, 0), -- Rodney Gallagher III
 (1019, 8, 0, 0, 0, 0, 64, 3, 0), -- Hudson Clement
 (1029, 8, 0, 0, 0, 0, 37, 3, 1), -- Traylon Ray
 (1034, 8, 0, 0, 0, 0, 31, 1, 0), -- Treylan Davis
 (1038, 8, 0, 0, 0, 0, 25, 2, 0), -- Kole Taylor
 (1025, 8, 0, 0, 0, 0, 0, 0, 0), -- Preston Fox

 -- Oklahoma State
 (652, 8, 116, 19, -15, 3, 0, 0, 1), -- Alan Bowman
 (654, 8, 75, 5, 0, 1, 0, 0, 1), -- Garret Rangel
 (660, 8, 0, 0, 50, 13, 8, 3, 0), -- Ollie Gordon II
 (665, 8, 0, 0, 3, 3, 1, 1, 0), -- Sesi Vailahi
 (680, 8, 0, 0, 0, 0, 73, 3, 0), -- Da'Wain Lofton
 (687, 8, 0, 0, 0, 0, 54, 2, 1), -- De'Zhaun Stribling
 (684, 8, 0, 0, 0, 0, 48, 3, 0), -- Brennan Presley
 (681, 8, 0, 0, 0, 0, 8, 1, 1), -- Rashod Owens
 (672, 8, 0, 0, 0, 0, 0, 0, 0), -- Cale Cabbiness
 (691, 8, 0, 0, 0, 0, -1, 1, 0), -- Josh Ford

 -- Baylor at Iowa State Offense
 -- Baylor
 (131, 9, 258, 44, 24, 3, 0, 0, 3), -- Sawyer Robertson
 (138, 9, 0, 0, 28, 8, 23, 1, 0), -- Bryson Washington
 (135, 9, 0, 0, 27, 9, 11, 1, 0), -- Dawson Pendergrass
 (149, 9, 0, 0, 0, 0, 66, 5, 1), -- Ketron Jackson Jr.
 (157, 9, 0, 0, 0, 0, 61, 6, 1), -- Michael Trigg
 (151, 9, 0, 0, 0, 0, 57, 5, 0), -- Hal Presley
 (140, 9, 0, 0, 0, 0, 19, 2, 0), -- Monaray Baldwin
 (148, 9, 0, 0, 0, 0, 11, 3, 0), -- Ashtyn Hawkins
 (144, 9, 0, 0, 0, 0, 10, 2, 1), -- Josh Cameron

 -- Iowa State
 (444, 9, 277, 25, 28, 3, 0, 0, 2), -- Rocco Becht
 (452, 9, 0, 0, 107, 15, 0, 0, 2), -- Jaylon Jackson
 (451, 9, 0, 0, 97, 15, 0, 0, 0), -- Carson Hansen
 (468, 9, 0, 0, 9, 2, 98, 5, 0), -- Jaylin Noel
 (454, 9, 0, 0, 7, 2, 0, 0, 0), -- Easton Miller
 (465, 9, 0, 0, 0, 0, 116, 8, 1), -- Jayden Higgins
 (476, 9, 0, 0, 0, 0, 49, 2, 1), -- Benjamin Brahmer
 (481, 9, 0, 0, 0, 0, 14, 1, 0), -- Tyler Moore

 -- Texas Tech at Arizona Offense
 -- Texas Tech
 (807, 10, 214, 29, -23, 4, 0, 0, 0), -- Behren Morton
 (809, 10, 0, 0, 128, 21, -2, 1, 3), -- Tahj Brooks
 (824, 10, 0, 0, 13, 1, 0, 0, 0), -- Drae McCray
 (811, 10, 0, 0, 1, 1, 0, 0, 0), -- Adam Hill
 (818, 10, 0, 0, 0, 0, 116, 5, 0), -- Caleb Douglas
 (821, 10, 0, 0, 0, 0, 38, 1, 0), -- Micah Hudson
 (823, 10, 0, 0, 0, 0, 27, 5, 0), -- Josh Kelly
 (833, 10, 0, 0, 0, 0, 14, 2, 0), -- Jalin Conyers
 (819, 10, 0, 0, 0, 0, 12, 2, 0), -- Coy Eakin
 (839, 10, 0, 0, 0, 0, 9, 1, 0), -- Mason Tharp
 (837, 10, 0, 0, 0, 0, 0, 0, 0), -- Johncarlos Miller II

 -- Arizona
 (4, 10, 301, 49, 4, 6, 0, 0, 0), -- Noah Fifita
 (7, 10, 0, 0, 97, 14, 39, 7, 1), -- Quali Conley
 (12, 10, 0, 0, 20, 10, 0, 0, 0), -- Kedrick Reescano
 (23, 10, 0, 0, 0, 0, 161, 8, 0), -- Tetairoa McMillan
 (29, 10, 0, 0, 0, 0, 46, 5, 0), -- Keyan Burnett
 (21, 10, 0, 0, 0, 0, 33, 3, 0), -- Montana Lemonious-Craig
 (26, 10, 0, 0, 0, 0, 18, 3, 0), -- Jeremiah Patterson
 (32, 10, 0, 0, 0, 0, 4, 2, 0), -- Sam Olson
 (19, 10, 0, 0, 0, 0, 0, 0, 0), -- Devin Hyatt

 -- Utah at Arizona State Offense
 -- Utah
 (936, 11, 209, 37, -13, 2, 0, 0, 0), -- Cameron Rising
 (940, 11, 0, 0, 129, 21, 61, 5, 1), -- Micah Bernard
 (971, 11, 0, 0, 19, 3, 44, 3, 0), -- Brant Kuithe
 (945, 11, 0, 0, 4, 4, 0, 0, 0), -- Dijon Stanley
 (958, 11, 0, 0, 3, 1, 19, 3, 0), -- Money Parks
 (946, 11, 0, 0, 0, 1, 0, 0, 0), -- Charlie Vincent
 (961, 11, 0, 0, 0, 0, 75, 4, 0), -- Dorian Singer
 (959, 11, 0, 0, 0, 0, 10, 1, 0), -- Mycah Pittman
 (949, 11, 0, 0, 0, 0, 0, 0, 0), -- Luca Caldarella

 -- Arizona State
 (66, 11, 154, 18, 22, 6, 0, 0, 1), -- Sam Leavitt
 (67, 11, 13, 2, 2, 1, 0, 0, 1), -- Jeff Sims
 (73, 11, 0, 0, 158, 22, 41, 4, 2), -- Cam Skattebo
 (68, 11, 0, 0, 15, 3, 7, 1, 0), -- DeCarlos Brooks
 (84, 11, 0, 0, 8, 1, 0, 0, 0), -- Jake Smith
 (87, 11, 0, 0, 0, 0, 84, 5, 1), -- Jordyn Tyson
 (79, 11, 0, 0, 0, 0, 27, 1, 0), -- Xavier Guillory
 (95, 11, 0, 0, 0, 0, 8, 1, 0), -- Chamon Metayer
 (86, 11, 0, 0, 0, 0, 0, 0, 0), -- Melquan Stovall

 -- Iowa State at West Virginia Offense
 -- Iowa State
 (444, 12, 265, 26, 0, 8, 0, 0, 1), -- Rocco Becht
 (451, 12, 0, 0, 96, 20, 0, 0, 3), -- Carson Hansen
 (452, 12, 0, 0, 19, 12, 6, 2, 0), -- Jaylon Jackson
 (468, 12, 0, 0, 9, 1, 77, 5, 1), -- Jaylin Noel
 (465, 12, 0, 0, 0, 0, 102, 6, 0), -- Jayden Higgins
 (464, 12, 0, 0, 0, 0, 46, 2, 0), -- Eli Green
 (476, 12, 0, 0, 0, 0, 15, 1, 0), -- Benjamin Brahmer
 (461, 12, 0, 0, 0, 0, 12, 1, 0), -- Carson Brown
 (477, 12, 0, 0, 0, 0, 7, 1, 0), -- Gabe Burkle
 (467, 12, 0, 0, 0, 0, 0, 0, 0), -- Beni Ngoyi

 -- West Virginia
 (1005, 12, 206, 31, 87, 10, 0, 0, 1), -- Garrett Greene
 (1016, 12, 0, 0, 46, 12, 10, 1, 2), -- Jahiem White
 (1012, 12, 0, 0, 17, 9, 0, 0, 0), -- CJ Donaldson Jr.
 (1038, 12, 0, 0, 0, 0, 55, 5, 0), -- Kole Taylor
 (1029, 12, 0, 0, 0, 0, 49, 3, 0), -- Traylon Ray
 (1019, 12, 0, 0, 0, 0, 39, 5, 0), -- Hudson Clement
 (1026, 12, 0, 0, 0, 0, 21, 1, 0), -- Rodney Gallagher III
 (1031, 12, 0, 0, 0, 0, 17, 2, 0), -- Justin Robinson
 (1034, 12, 0, 0, 0, 0, 15, 1, 0), -- Treylan Davis
 (1025, 12, 0, 0, 0, 0, 0, 0, 0), -- Preston Fox

 -- Kansas State at Colorado Offense
 -- Kansas State
 (519, 13, 224, 23, -15, 7, 0, 0, 3), -- Avery Johnson
 (521, 13, 14, 3, 0, 0, 0, 0, 0), -- Ta'Quan Roberson
 (524, 13, 0, 0, 182, 25, 38, 2, 0), -- DJ Giddens
 (523, 13, 0, 0, 21, 7, 27, 3, 1), -- Dylan Edwards
 (534, 13, 0, 0, 0, 1, 14, 1, 0), -- Jadon Jackson
 (530, 13, 0, 0, 0, 0, 121, 6, 2), -- Jayce Brown
 (550, 13, 0, 0, 0, 0, 17, 2, 0), -- Garrett Oakley
 (531, 13, 0, 0, 0, 0, 16, 2, 0), -- Dante Cephas
 (552, 13, 0, 0, 0, 0, 5, 1, 0), -- Will Swanson
 (542, 13, 0, 0, 0, 0, 0, 0, 0), -- Tre Spivey

 -- Colorado
 (312, 13, 388, 40, -50, 9, 0, 0, 3), -- Shedeur Sanders
 (318, 13, 0, 0, 11, 7, 19, 3, 0), -- Dallan Hayden
 (316, 13, 0, 0, 10, 3, 4, 1, 1), -- Isaiah Augustave
 (331, 13, 0, 0, 0, 0, 145, 8, 0), -- Omarion Miller
 (334, 13, 0, 0, 0, 0, 83, 5, 1), -- Will Sheppard
 (338, 13, 0, 0, 0, 0, 58, 5, 2), -- LaJohntay Wester
 (330, 13, 0, 0, 0, 0, 27, 5, 0), -- Drelon Miller
 (326, 13, 0, 0, 0, 0, 26, 3, 0), -- Travis Hunter
 (325, 13, 0, 0, 0, 0, 20, 3, 0), -- Jimmy Horn Jr.


 -- Oklahoma State at BYU Offense
 -- Oklahoma State
 (652, 14, 85, 19, 19, 3, 11, 1, 2), -- Alan Bowman
 (654, 14, 51, 9, 77, 5, 0, 0, 1), -- Garret Rangel
 (684, 14, 16, 1, 11, 1, 43, 5, 2), -- Brennan Presley
 (660, 14, 0, 0, 107, 16, 20, 3, 3), -- Ollie Gordon II
 (659, 14, 0, 0, 38, 8, 0, 0, 0), -- Rodney Fields Jr.
 (665, 14, 0, 0, 17, 4, 0, 0, 0), -- Sesi Vailahi
 (685, 14, 0, 0, 0, 0, 33, 2, 0), -- Talyn Shettron
 (681, 14, 0, 0, 0, 0, 20, 2, 0), -- Rashod Owens
 (680, 14, 0, 0, 0, 0, 11, 2, 0), -- Da'Wain Lofton
 (686, 14, 0, 0, 0, 0, 8, 1, 0), -- Ayo Shotomide-King
 (691, 14, 0, 0, 0, 0, 5, 1, 0), -- Josh Ford
 (692, 14, 0, 0, 0, 0, 1, 1, 0), -- Tyler Foster
 (687, 14, 0, 0, 0, 0, 0, 0, 0), -- De'Zhaun Stribling

 -- BYU
 (189, 14, 218, 26, 81, 9, 0, 0, 3), -- Jake Retzlaff
 (197, 14, 0, 1, 47, 6, 0, 0, 0), -- Hinckley Ropati
 (193, 14, 0, 0, 120, 20, 0, 0, 2), -- LJ Martin
 (202, 14, 0, 0, 7, 1, 0, 0, 0), -- Parker Kingston
 (203, 14, 0, 0, 0, 0, 129, 6, 1), -- Darius Lassiter
 (204, 14, 0, 0, 0, 0, 56, 2, 1), -- Keelan Marion
 (209, 14, 0, 0, 0, 0, 25, 3, 0), -- Chase Roberts
 (221, 14, 0, 0, 0, 0, 6, 1, 0), -- Ryner Swanson
 (217, 14, 0, 0, 0, 0, 2, 1, 0), -- Keanu Hill
 (207, 14, 0, 0, 0, 0, 0, 0, 0), -- Jojo Phillips
 (220, 14, 0, 0, 0, 0, 0, 0, 0), -- Ray Paulo
 (215, 14, 0, 0, 0, 0, 0, 0, 0), -- Ethan Erickson
 (222, 14, 0, 0, 0, 0, 0, 0, 0), -- Mata'ava Ta'ase

 -- Baylor at Texas Tech Offense
 -- Baylor
 (131, 15, 274, 32, 16, 4, 0, 0, 5), -- Sawyer Robertson
 (138, 15, 0, 0, 116, 10, 24, 3, 2), -- Bryson Washington
 (129, 15, 0, 0, 40, 2, 0, 0, 1), -- Dequan Finn
 (135, 15, 0, 0, 36, 7, 2, 1, 0), -- Dawson Pendergrass
 (141, 15, 0, 0, 25, 3, 0, 0, 0), -- Jamaal Bell
 (136, 15, 0, 0, 20, 6, 24, 1, 0), -- Richard Reese
 (140, 15, 0, 0, 2, 1, 26, 2, 1), -- Monaray Baldwin
 (144, 15, 0, 0, 0, 0, 75, 6, 3), -- Josh Cameron
 (148, 15, 0, 0, 0, 0, 69, 6, 0), -- Ashtyn Hawkins
 (151, 15, 0, 0, 0, 0, 35, 1, 1), -- Hal Presley
 (157, 15, 0, 0, 0, 0, 19, 1, 0), -- Michael Trigg

 -- Texas Tech
 (807, 15, 286, 49, 3, 6, 0, 0, 3), -- Behren Morton
 (833, 15, 20, 1, 0, 0, 0, 0, 1), -- Jalin Conyers
 (809, 15, 0, 0, 125, 25, 22, 4, 1), -- Tahj Brooks
 (810, 15, 0, 0, 21, 4, 0, 1, 0), -- Cameron Dickey
 (818, 15, 0, 0, 0, 0, 99, 9, 3), -- Caleb Douglas
 (823, 15, 0, 0, 0, 0, 76, 9, 0), -- Josh Kelly
 (821, 15, 0, 0, 0, 0, 38, 2, 0), -- Micah Hudson
 (814, 15, 0, 0, 0, 0, 22, 2, 1), -- J'Koby Williams
 (819, 15, 0, 0, 0, 0, 20, 3, 0), -- Coy Eakin
 (837, 15, 0, 0, 0, 0, 13, 1, 0), -- Johncarlos Miller II
 (816, 15, 0, 0, 0, 0, 11, 2, 0), -- Jordan Brown
 (824, 15, 0, 0, 0, 0, 5, 1, 0), -- Drae McCray
 (839, 15, 0, 0, 0, 0, 0, 0, 0), -- Mason Tharp

 -- Colorado at Arizona Offense
 -- Colorado
 (312, 16, 250, 33, 6, 7, 0, 0, 3), -- Shedeur Sanders
 (313, 16, 0, 1, 0, 0, 0, 0, 0), -- Ryan Staub
 (316, 16, 0, 0, 53, 14, 7, 1, 1), -- Isaiah Augustave
 (320, 16, 0, 0, 53, 7, 0, 0, 0), -- Charlie Offerdahl
 (318, 16, 0, 0, 35, 6, 7, 1, 0), -- Dallan Hayden
 (322, 16, 0, 0, 8, 1, 0, 0, 0), -- Micah Welch
 (338, 16, 0, 0, 0, 0, 127, 8, 0), -- LaJohntay Wester
 (334, 16, 0, 0, 0, 0, 54, 4, 1), -- Will Sheppard
 (330, 16, 0, 0, 0, 0, 18, 3, 1), -- Drelon Miller
 (326, 16, 0, 0, 0, 0, 17, 2, 0), -- Travis Hunter
 (343, 16, 0, 0, 0, 0, 10, 1, 0), -- Sav'ell Smalls
 (325, 16, 0, 0, 0, 0, 9, 2, 0), -- Jimmy Horn Jr.
 (332, 16, 0, 0, 0, 0, 1, 1, 0), -- Jordan Onovughe
 (341, 16, 0, 0, 0, 0, 0, 0, 0), -- Morgan Pearson

 -- Arizona
 (4, 16, 138, 26, 24, 12, 0, 0, 1), -- Noah Fifita
 (7, 16, 0, 0, 42, 11, 12, 3, 0), -- Quali Conley
 (12, 16, 0, 0, 26, 7, 0, 0, 0), -- Kedrick Reescano
 (10, 16, 0, 0, 11, 1, 0, 0, 0), -- Kayden Luke
 (9, 16, 0, 0, 8, 2, 0, 0, 0), -- Brandon Johnson
 (6, 16, 0, 0, -4, 1, 0, 0, 0), -- Cole Tannenbaum
 (23, 16, 0, 0, 0, 0, 38, 5, 0), -- Tetairoa McMillan
 (26, 16, 0, 0, 0, 0, 31, 2, 0), -- Jeremiah Patterson
 (18, 16, 0, 0, 0, 0, 30, 4, 1), -- Chris Hunter
 (32, 16, 0, 0, 0, 0, 27, 2, 0), -- Sam Olson
 (19, 16, 0, 0, 0, 0, 0, 0, 0), -- Devin Hyatt
 (16, 16, 0, 0, 0, 0, 0, 0, 0), -- Rex Haynes

 -- Kansas State at West Virginia Offense
 -- Kansas State
 (519, 17, 298, 29, 0, 0, 0, 0, 3), -- Avery Johnson
 (524, 17, 0, 0, 57, 19, 53, 1, 2), -- DJ Giddens
 (525, 17, 0, 0, 32, 2, 0, 0, 0), -- Joe Jackson
 (523, 17, 0, 0, 27, 3, 18, 3, 0), -- Dylan Edwards
 (534, 17, 0, 0, 0, 0, 84, 2, 1), -- Jadon Jackson
 (535, 17, 0, 0, 0, 0, 46, 3, 0), -- Keagan Johnson
 (529, 17, 0, 0, 0, 0, 27, 3, 0), -- Ty Bowman
 (530, 17, 0, 0, 0, 0, 22, 2, 0), -- Jayce Brown
 (550, 17, 0, 0, 0, 0, 20, 2, 1), -- Garrett Oakley
 (546, 17, 0, 0, 0, 0, 19, 2, 1), -- Will Anciaux
 (531, 17, 0, 0, 0, 0, 9, 1, 0), -- Dante Cephas
 (552, 17, 0, 0, 0, 0, 0, 0, 0), -- Will Swanson

 -- West Virginia
 (1005, 17, 85, 19, 89, 11, 0, 0, 1), -- Garrett Greene
 (1007, 17, 58, 13, 0, 9, 0, 0, 1), -- Nicco Marchiol
 (1012, 17, 0, 0, 34, 12, 0, 1, 0), -- CJ Donaldson Jr.
 (1016, 17, 0, 0, 18, 7, 8, 1, 0), -- Jahiem White
 (1026, 17, 0, 0, 10, 1, 8, 1, 0), -- Rodney Gallagher III
 (1009, 17, 0, 0, 1, 3, 0, 0, 0), -- Jaylen Anderson
 (1034, 17, 0, 0, 0, 0, 0, 0, 0), -- Treylan Davis
 (1038, 17, 0, 0, 0, 0, 61, 4, 0), -- Kole Taylor
 (1029, 17, 0, 0, 0, 0, 37, 4, 1), -- Traylon Ray
 (1019, 17, 0, 0, 0, 0, 29, 4, 1), -- Hudson Clement
 (1031, 17, 0, 0, 0, 0, 0, 0, 0), -- Justin Robinson
 (1024, 17, 0, 0, 0, 0, 0, 0, 0), -- Ric'Darious Farmer
 (1025, 17, 0, 0, 0, 0, 0, 0, 0), -- Preston Fox

 -- Oklahoma State at Baylor Offense
 -- Oklahoma State
 (652, 18, 359, 42, -38, 4, 0, 0, 1), -- Alan Bowman
 (660, 18, 0, 0, 77, 18, 15, 4, 2), -- Ollie Gordon II
 (659, 18, 0, 0, 19, 5, 23, 2, 0), -- Rodney Fields Jr.
 (665, 18, 0, 0, 10, 5, 0, 0, 0), -- Sesi Vailahi
 (662, 18, 0, 0, 6, 1, 0, 0, 0), -- Trent Howland
 (684, 18, 0, 0, 0, 1, 183, 15, 1), -- Brennan Presley
 (681, 18, 0, 0, 0, 0, 62, 3, 0), -- Rashod Owens
 (680, 18, 0, 0, 0, 0, 56, 1, 0), -- Da'Wain Lofton
 (687, 18, 0, 0, 0, 0, 15, 2, 0), -- De'Zhaun Stribling
 (669, 18, 0, 0, 0, 0, 5, 1, 0), -- Jake Schultz
 (685, 18, 0, 0, 0, 0, 0, 0, 0), -- Talyn Shettron
 (686, 18, 0, 0, 0, 0, 0, 0, 0), -- Ayo Shotomide-King
 (691, 18, 0, 0, 0, 0, 0, 0, 0), -- Josh Ford

 -- Baylor
 (131, 18, 222, 19, 73, 8, 0, 0, 4), -- Sawyer Robertson
 (128, 18, 0, 1, 0, 0, 0, 0, 0), -- Nate Bennett
 (135, 18, 0, 0, 142, 6, 8, 1, 1), -- Dawson Pendergrass
 (138, 18, 0, 0, 78, 17, 0, 0, 0), -- Bryson Washington
 (136, 18, 0, 0, 52, 6, 0, 0, 0), -- Richard Reese
 (148, 18, 0, 0, 0, 0, 74, 4, 1), -- Ashtyn Hawkins
 (151, 18, 0, 0, 0, 0, 65, 2, 1), -- Hal Presley
 (157, 18, 0, 0, 0, 0, 38, 1, 0), -- Michael Trigg
 (140, 18, 0, 0, 0, 0, 23, 1, 0), -- Monaray Baldwin
 (144, 18, 0, 0, 0, 0, 13, 1, 0), -- Josh Cameron
 (154, 18, 0, 0, 0, 0, 1, 1, 1), -- Matthew Klopfenstein

 -- West Virginia at Arizona Offense
 -- West Virginia
 (1007, 19, 198, 22, 39, 11, 0, 0, 2), -- Nicco Marchiol
 (1016, 19, 0, 0, 92, 12, 10, 3, 0), -- Jahiem White
 (1026, 19, 0, 0, 21, 4, 14, 2, 0), -- Rodney Gallagher III
 (1063, 19, 0, 0, 14, 1, 0, 0, 1), -- Leighton Bechdel
 (1025, 19, 0, 0, 0, 1, 0, 0, 0), -- Preston Fox
 (1029, 19, 0, 0, 0, 0, 78, 2, 1), -- Traylon Ray
 (1038, 19, 0, 0, 0, 0, 28, 3, 0), -- Kole Taylor
 (1031, 19, 0, 0, 0, 0, 28, 3, 0), -- Justin Robinson
 (1019, 19, 0, 0, 0, 0, 20, 2, 1), -- Hudson Clement
 (1009, 19, 0, 0, 0, 0, 9, 1, 0), -- Jaylen Anderson
 (1034, 19, 0, 0, 0, 0, 8, 1, 0), -- Treylan Davis

 -- Arizona
 (4, 19, 294, 32, -5, 5, 14, 1, 3), -- Noah Fifita
 (23, 19, 14, 2, 0, 0, 202, 10, 1), -- Tetairoa McMillan
 (7, 19, 0, 0, 72, 16, 14, 2, 1), -- Quali Conley
 (18, 19, 0, 0, 7, 1, 26, 3, 0), -- Chris Hunter
 (12, 19, 0, 0, 4, 3, 1, 1, 0), -- Kedrick Reescano
 (32, 19, 0, 0, 0, 0, 32, 2, 1), -- Sam Olson
 (29, 19, 0, 0, 0, 0, 12, 2, 0), -- Keyan Burnett
 (26, 19, 0, 0, 0, 0, 7, 1, 0), -- Jeremiah Patterson
 (21, 19, 0, 0, 0, 0, 0, 0, 0), -- Montana Lemonious-Craig

 -- Utah at Houston Offense
 -- Utah
 (938, 20, 171, 22, 3, 5, 0, 0, 1), -- Isaac Wilson
 (937, 20, 45, 15, 3, 3, 0, 0, 0), -- Brandon Rose
 (940, 20, 0, 0, 51, 14, 25, 4, 1), -- Micah Bernard
 (942, 20, 0, 0, 33, 4, 0, 0, 0), -- Jaylon Glover
 (971, 20, 0, 0, 0, 0, 113, 5, 1), -- Brant Kuithe
 (961, 20, 0, 0, 0, 0, 54, 6, 0), -- Dorian Singer
 (955, 20, 0, 0, 0, 0, 7, 1, 0), -- Munir McClain
 (973, 20, 0, 0, 0, 0, 7, 1, 0), -- Carsen Ryan
 (958, 20, 0, 0, 0, 0, 6, 1, 0), -- Money Parks
 (959, 20, 0, 0, 0, 0, 4, 2, 0), -- Mycah Pittman
 (964, 20, 0, 0, 0, 0, 0, 0, 0), -- Daidren Zipperer
 (949, 20, 0, 0, 0, 0, 0, 0, 0), -- Luca Caldarella
 (970, 20, 0, 0, 0, 0, 0, 0, 0), -- Landen King
 (965, 20, 0, 0, 0, 0, 0, 0, 0), -- Dallen Bentley

 -- Houston
 (372, 20, 61, 13, 45, 17, 0, 0, 2), -- Zeon Chriss
 (378, 20, 0, 0, 81, 8, 7, 1, 0), -- J'Marion Burnette
 (383, 20, 0, 0, 72, 16, 0, 0, 0), -- Re'Shaun Sanford II
 (385, 20, 0, 0, 32, 8, 0, 1, 0), -- Stacy Sneed
 (393, 20, 0, 0, 0, 0, 28, 1, 1), -- Joseph Manjack IV
 (392, 20, 0, 0, 0, 0, 21, 1, 1), -- Stephon Johnson
 (401, 20, 0, 0, 0, 0, 3, 1, 0), -- Devan Williams
 (406, 20, 0, 0, 0, 0, 2, 1, 0), -- Maliq Carr
 (402, 20, 0, 0, 0, 0, 0, 0, 0), -- Jonah Wilson
 (412, 20, 0, 0, 0, 0, 0, 0, 0), -- Jayden York
 (394, 20, 0, 0, 0, 0, 0, 0, 0), -- Mekhi Mews

 -- Kansas at Kansas State Offense
 -- Kansas
 (586, 21, 209, 31, 66, 15, 0, 0, 2), -- Jalon Daniels
 (595, 21, 0, 0, 66, 13, 36, 5, 1), -- Devin Neal
 (594, 21, 0, 0, 45, 3, 0, 0, 1), -- Sevion Morrison
 (603, 21, 0, 0, 9, 2, 66, 4, 1), -- Luke Grimm
 (584, 21, 0, 0, 6, 1, 0, 0, 0), -- Cole Ballard
 (612, 21, 0, 0, 0, 0, 69, 4, 0), -- Trevor Wilson
 (599, 21, 0, 0, 0, 0, 24, 3, 0), -- Lawrence Arnold
 (615, 21, 0, 0, 0, 0, 14, 2, 0), -- Jared Casey
 (611, 21, 0, 0, 0, 0, 0, 0, 0), -- Quentin Skinner
 (592, 21, 0, 0, 0, 0, 0, 0, 0), -- Torry Locklin
 (620, 21, 0, 0, 0, 0, 0, 0, 0), -- Trevor Kardell

 -- Kansas State
 (519, 21, 253, 34, 67, 14, 0, 0, 3), -- Avery Johnson
 (524, 21, 0, 0, 102, 18, 15, 1, 0), -- DJ Giddens
 (523, 21, 0, 0, 60, 3, 20, 2, 0), -- Dylan Edwards
 (530, 21, 0, 0, 0, 0, 98, 5, 0), -- Jayce Brown
 (535, 21, 0, 0, 0, 0, 57, 4, 0), -- Keagan Johnson
 (546, 21, 0, 0, 0, 0, 29, 2, 1), -- Will Anciaux
 (531, 21, 0, 0, 0, 0, 21, 2, 0), -- Dante Cephas
 (552, 21, 0, 0, 0, 0, 8, 1, 0), -- Will Swanson
 (534, 21, 0, 0, 0, 0, 3, 1, 0), -- Jadon Jackson
 (550, 21, 0, 0, 0, 0, 2, 1, 1), -- Garrett Oakley

 -- Texas Tech at Iowa State Offense
 -- Texas Tech
 (807, 22, 237, 40, 6, 8, 0, 0, 2), -- Behren Morton
 (809, 22, 0, 0, 122, 25, 10, 2, 1), -- Tahj Brooks
 (814, 22, 0, 0, 1, 1, 2, 1, 0), -- J'Koby Williams
 (823, 22, 0, 0, 0, 0, 127, 8, 2), -- Josh Kelly
 (818, 22, 0, 0, 0, 0, 35, 5, 0), -- Caleb Douglas
 (819, 22, 0, 0, 0, 0, 32, 2, 0), -- Coy Eakin
 (839, 22, 0, 0, 0, 0, 18, 2, 0), -- Mason Tharp
 (816, 22, 0, 0, 0, 0, 13, 1, 0), -- Jordan Brown

 -- Iowa State
 (444, 22, 299, 38, 1, 8, 0, 0, 2), -- Rocco Becht
 (451, 22, 0, 0, 46, 11, 8, 1, 0), -- Carson Hansen
 (452, 22, 0, 0, 12, 6, 0, 0, 0), -- Jaylon Jackson
 (465, 22, 0, 0, 0, 0, 140, 10, 1), -- Jayden Higgins
 (477, 22, 0, 0, 0, 0, 45, 4, 0), -- Gabe Burkle
 (468, 22, 0, 0, 0, 0, 44, 5, 0), -- Jaylin Noel
 (461, 22, 0, 0, 0, 0, 44, 1, 1), -- Carson Brown
 (481, 22, 0, 0, 0, 0, 18, 1, 0), -- Tyler Moore

 -- West Virginia at Cincinnati Offense
 -- West Virginia
 (1007, 23, 156, 15, 18, 9, 0, 0, 2), -- Nicco Marchiol
 (1016, 23, 0, 0, 64, 13, 28, 1, 0), -- Jahiem White
 (1026, 23, 0, 0, -1, 1, 0, 0, 0), -- Rodney Gallagher III
 (1031, 23, 0, 0, 0, 0, 60, 2, 1), -- Justin Robinson
 (1029, 23, 0, 0, 0, 0, 38, 1, 0), -- Traylon Ray
 (1038, 23, 0, 0, 0, 0, 30, 5, 0), -- Kole Taylor
 (1024, 23, 0, 0, 0, 0, 0, 0, 0), -- Ric'Darious Farmer
 (1025, 23, 0, 0, 0, 0, 0, 0, 0), -- Preston Fox

 -- Cincinnati
 (255, 23, 279, 36, 48, 14, 0, 0, 2), -- Brendan Sorsby
 (261, 23, 0, 0, 91, 25, 18, 2, 1), -- Corey Kiner
 (262, 23, 0, 0, 18, 4, 100, 5, 1), -- Evan Pryor
 (266, 23, 0, 0, 0, 0, 68, 8, 0), -- Xzavier Henderson
 (268, 23, 0, 0, 0, 0, 41, 4, 0), -- Tony Johnson
 (280, 23, 0, 0, 0, 0, 31, 4, 0), -- Joe Royer
 (271, 23, 0, 0, 0, 0, 21, 2, 0), -- Jamoi Mayes

 -- Iowa State at Kansas Offense
 -- Iowa State
 (444, 24, 383, 37, 9, 8, 0, 0, 3), -- Rocco Becht
 (451, 24, 0, 0, 48, 8, 16, 1, 1), -- Carson Hansen
 (452, 24, 0, 0, 2, 2, 27, 1, 1), -- Jaylon Jackson
 (468, 24, 0, 0, -1, 1, 167, 8, 2), -- Jaylin Noel
 (465, 24, 0, 0, 0, 0, 88, 7, 0), -- Jayden Higgins
 (480, 24, 0, 0, 0, 0, 28, 1, 0), -- Stevo Klotz
 (477, 24, 0, 0, 0, 0, 21, 2, 0), -- Gabe Burkle
 (461, 24, 0, 0, 0, 0, 13, 1, 0), -- Carson Brown
 (469, 24, 0, 0, 0, 0, 9, 1, 0), -- Dominic Overby
 (481, 24, 0, 0, 0, 0, 9, 1, 0), -- Tyler Moore
 (464, 24, 0, 0, 0, 0, 5, 1, 0), -- Eli Green

 -- Kansas
 (586, 24, 295, 24, 68, 12, 0, 0, 3), -- Jalon Daniels
 (595, 24, 0, 0, 116, 18, 22, 2, 2), -- Devin Neal
 (603, 24, 0, 0, 0, 0, 76, 2, 1), -- Luke Grimm
 (592, 24, 0, 0, 0, 1, 31, 1, 0), -- Torry Locklin
 (611, 24, 0, 0, 0, 0, 135, 4, 1), -- Quentin Skinner
 (620, 24, 0, 0, 0, 0, 24, 2, 0), -- Trevor Kardell
 (615, 24, 0, 0, 0, 0, 7, 1, 0), -- Jared Casey
 (599, 24, 0, 0, 0, 0, 0, 0, 0), -- Lawrence Arnold
 (617, 24, 0, 0, 0, 0, 0, 0, 0), -- Leyton Cure

 -- Colorado at Texas Tech Offense
 -- Colorado
 (312, 25, 291, 43, 16, 9, 0, 0, 4), -- Shedeur Sanders
 (316, 25, 0, 0, 32, 10, 21, 3, 0), -- Isaiah Augustave
 (318, 25, 0, 0, 17, 6, -5, 2, 0), -- Dallan Hayden
 (330, 25, 0, 0, -1, 1, 5, 1, 0), -- Drelon Miller
 (326, 25, 0, 0, 0, 0, 99, 9, 1), -- Travis Hunter
 (338, 25, 0, 0, 0, 0, 82, 6, 1), -- LaJohntay Wester
 (334, 25, 0, 0, 0, 0, 79, 8, 1), -- Will Sheppard
 (343, 25, 0, 0, 0, 0, 10, 1, 0), -- Sav'ell Smalls

 -- Texas Tech
 (807, 25, 275, 40, -36, 11, 0, 0, 2), -- Behren Morton
 (836, 25, 0, 1, 0, 0, 0, 0, 0), -- Jason Llewellyn
 (809, 25, 0, 0, 137, 31, 51, 4, 1), -- Tahj Brooks
 (814, 25, 0, 0, 12, 4, 0, 0, 0), -- J'Koby Williams
 (823, 25, 0, 0, 0, 0, 106, 8, 0), -- Josh Kelly
 (833, 25, 0, 0, 0, 0, 50, 3, 2), -- Jalin Conyers
 (819, 25, 0, 0, 0, 0, 40, 4, 0), -- Coy Eakin
 (818, 25, 0, 0, 0, 0, 16, 3, 0), -- Caleb Douglas
 (816, 25, 0, 0, 0, 0, 7, 1, 0), -- Jordan Brown
 (837, 25, 0, 0, 0, 0, 5, 1, 0), -- Johncarlos Miller II

 -- UCF at Arizona State Offense
 -- UCF
 (874, 26, 229, 34, -14, 5, 0, 0, 0), -- Dylan Rizk
 (879, 26, 0, 0, 127, 25, 10, 2, 3), -- RJ Harvey
 (881, 26, 0, 0, 34, 4, 0, 0, 0), -- Myles Montgomery
 (888, 26, 0, 0, 20, 1, 0, 0, 0), -- Ja'Varrius Johnson
 (870, 26, 0, 0, 6, 1, 0, 0, 1), -- Jacurri Brown
 (882, 26, 0, 0, 4, 1, 8, 1, 0), -- Johnny Richardson
 (902, 26, 0, 0, 0, 0, 62, 4, 0), -- Randy Pittman Jr.
 (887, 26, 0, 0, 0, 0, 56, 7, 0), -- Kobe Hudson
 (889, 26, 0, 0, 0, 0, 55, 7, 0), -- Jacoby Jones
 (884, 26, 0, 0, 0, 0, 20, 2, 0), -- Jarrad Baker
 (896, 26, 0, 0, 0, 0, 18, 1, 0), -- Trent Whittemore

 -- Arizona State
 (66, 26, 161, 25, 22, 11, 0, 0, 3), -- Sam Leavitt
 (69, 26, 0, 0, 73, 18, 21, 3, 0), -- Kyson Brown
 (68, 26, 0, 0, 4, 3, 0, 0, 0), -- DeCarlos Brooks
 (87, 26, 0, 0, 0, 0, 99, 7, 2), -- Jordyn Tyson
 (86, 26, 0, 0, 0, 0, 12, 1, 0), -- Melquan Stovall
 (95, 26, 0, 0, 0, 0, 10, 3, 1), -- Chamon Metayer
 (84, 26, 0, 0, 0, 0, 10, 1, 0), -- Jake Smith
 (79, 26, 0, 0, 0, 0, 9, 1, 0), -- Xavier Guillory

 -- Oklahoma State at TCU Offense
 -- Oklahoma State
 (652, 27, 141, 29, -9, 1, 0, 0, 1), -- Alan Bowman
 (655, 27, 92, 8, -23, 1, 0, 0, 0), -- Maealiuaki Smith
 (660, 27, 0, 0, 121, 25, 3, 2, 1), -- Ollie Gordon II
 (662, 27, 0, 0, 47, 8, 5, 2, 0), -- Trent Howland
 (687, 27, 0, 0, 0, 0, 101, 7, 1), -- De'Zhaun Stribling
 (684, 27, 0, 0, 0, 0, 75, 10, 0), -- Brennan Presley
 (679, 27, 0, 0, 0, 0, 28, 1, 0), -- Camron Heard
 (665, 27, 0, 0, 0, 0, 14, 1, 0), -- Sesi Vailahi
 (672, 27, 0, 0, 0, 0, 7, 1, 0), -- Cale Cabbiness
 (686, 27, 0, 0, 0, 0, 0, 0, 0), -- Ayo Shotomide-King
 (669, 27, 0, 0, 0, 0, 0, 1, 0), -- Jake Schultz

 -- TCU
 (731, 27, 286, 35, 1, 3, 0, 0, 1), -- Josh Hoover
 (734, 27, 6, 1, 0, 0, 0, 0, 0), -- Ken Seals
 (764, 27, 1, 1, 19, 5, 52, 7, 2), -- Savion Williams
 (745, 27, 0, 0, 59, 1, 11, 2, 1), -- Jordyn Bailey
 (738, 27, 0, 0, 47, 7, 9, 1, 2), -- Cam Cook
 (736, 27, 0, 0, 26, 4, 0, 0, 0), -- Trent Battle
 (744, 27, 0, 0, 11, 2, 0, 0, 0), -- Trey Sanders
 (742, 27, 0, 0, 7, 2, 5, 1, 0), -- Jeremy Payne
 (739, 27, 0, 0, 5, 3, 0, 0, 0), -- Franklin Estrada II
 (740, 27, 0, 0, 0, 1, 0, 0, 0), -- Dominique Johnson
 (761, 27, 0, 0, 0, 0, 100, 7, 0), -- JP Richardson
 (747, 27, 0, 0, 0, 0, 59, 5, 0), -- Jack Bech
 (759, 27, 0, 0, 0, 0, 41, 3, 0), -- Eric McAlister
 (771, 27, 0, 0, 0, 0, 10, 1, 0), -- DJ Rogers
 (748, 27, 0, 0, 0, 0, 6, 1, 0), -- Parker Clark
 (767, 27, 0, 0, 0, 0, 0, 0, 0), -- Drake Dabney

 -- BYU at Utah Offense
 -- BYU
 (189, 28, 219, 33, -12, 8, 0, 0, 1), -- Jake Retzlaff
 (193, 28, 0, 0, 68, 11, 0, 0, 0), -- LJ Martin
 (197, 28, 0, 0, 38, 8, 0, 0, 0), -- Hinckley Ropati
 (204, 28, 0, 0, 12, 2, 19, 1, 0), -- Keelan Marion
 (209, 28, 0, 0, 9, 2, 91, 6, 0), -- Chase Roberts
 (195, 28, 0, 0, 5, 1, 0, 0, 0), -- Sione I Moa
 (238, 28, 0, 0, 0, 0, 0, 0, 0), -- Bruce Mitchell
 (203, 28, 0, 0, 0, 0, 46, 4, 0), -- Darius Lassiter
 (207, 28, 0, 0, 0, 0, 41, 2, 0), -- Jojo Phillips
 (202, 28, 0, 0, 0, 0, 22, 2, 0), -- Parker Kingston
 (217, 28, 0, 0, 0, 0, 0, 0, 0), -- Keanu Hill

 -- Utah
 (937, 28, 112, 21, 55, 7, 0, 0, 2), -- Brandon Rose
 (948, 28, 0, 1, 0, 0, 0, 0, 0), -- Damien Alford
 (940, 28, 0, 0, 78, 17, 6, 2, 1), -- Micah Bernard
 (942, 28, 0, 0, 12, 4, 0, 0, 0), -- Jaylon Glover
 (971, 28, 0, 0, 2, 2, 23, 4, 2), -- Brant Kuithe
 (961, 28, 0, 0, 0, 0, 76, 5, 0), -- Dorian Singer
 (973, 28, 0, 0, 0, 0, 7, 1, 0), -- Carsen Ryan
 (955, 28, 0, 0, 0, 0, 0, 0, 0), -- Munir McClain
 (970, 28, 0, 0, 0, 0, 0, 0, 0), -- Landen King

 -- Houston at Arizona Offense
 -- Houston
 (372, 29, 191, 27, 55, 18, 0, 0, 0), -- Zeon Chriss
 (373, 29, 0, 1, 0, 0, 0, 0, 0), -- Holman Edwards
 (383, 29, 0, 0, 76, 10, 40, 5, 0), -- Re'Shaun Sanford II
 (378, 29, 0, 0, 10, 2, 0, 0, 0), -- J'Marion Burnette
 (379, 29, 0, 0, 2, 1, 6, 1, 0), -- DJ Butler
 (393, 29, 0, 0, 0, 0, 60, 2, 0), -- Joseph Manjack IV
 (375, 29, 0, 0, 0, 1, 0, 0, 0), -- Donovan Smith
 (394, 29, 0, 0, -3, 1, 16, 3, 0), -- Mekhi Mews
 (401, 29, 0, 0, -5, 1, 0, 0, 0), -- Devan Williams
 (392, 29, 0, 0, 0, 0, 70, 4, 0), -- Stephon Johnson
 (412, 29, 0, 0, 0, 0, 0, 0, 0), -- Jayden York
 (385, 29, 0, 0, 0, 0, 0, 0, 0), -- Stacy Sneed
 (406, 29, 0, 0, 0, 0, -1, 1, 0), -- Maliq Carr

 -- Arizona
 (4, 29, 224, 35, -9, 11, 0, 0, 2), -- Noah Fifita
 (7, 29, 0, 0, 107, 11, 27, 3, 2), -- Quali Conley
 (12, 29, 0, 0, 28, 11, 12, 1, 0), -- Kedrick Reescano
 (56, 29, 0, 0, -9, 1, 0, 0, 0), -- Michael Salgado-Medina
 (23, 29, 0, 0, 0, 0, 70, 6, 1), -- Tetairoa McMillan
 (18, 29, 0, 0, 0, 0, 65, 6, 0), -- Chris Hunter
 (32, 29, 0, 0, 0, 0, 31, 1, 0), -- Sam Olson
 (26, 29, 0, 0, 0, 0, 13, 2, 0), -- Jeremiah Patterson
 (33, 29, 0, 0, 0, 0, 6, 1, 0); -- Tyler Powell
GO