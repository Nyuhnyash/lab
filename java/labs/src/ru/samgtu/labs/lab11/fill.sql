INSERT INTO genres (name) VALUES
    ('Rock'),
    ('Hard Rock'),
    ('Pop Rock'),
    ('Art Rock'),
    ('Progressive Rock')
;

INSERT INTO singers (name)
VALUES ('Queen'),
       ('The Beatles');

-- Album: (.+), (.+)
-- \('$1', \(SELECT id FROM genres WHERE name = '$2'\), \(SELECT id FROM singers WHERE name = 'Queen'\)\),

INSERT INTO albums (title, genreId, singerId) VALUES
('Queen', (SELECT id FROM genres WHERE name = 'Hard Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('Queen II', (SELECT id FROM genres WHERE name = 'Art Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('Sheer Heart Attack', (SELECT id FROM genres WHERE name = 'Hard Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('A Night at the Opera', (SELECT id FROM genres WHERE name = 'Progressive Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('A Day at the Races', (SELECT id FROM genres WHERE name = 'Hard Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('News of the World', (SELECT id FROM genres WHERE name = 'Hard Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('Jazz', (SELECT id FROM genres WHERE name = 'Hard Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('The Game', (SELECT id FROM genres WHERE name = 'Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('Flash Gordon', (SELECT id FROM genres WHERE name = 'Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('Hot Space', (SELECT id FROM genres WHERE name = 'Pop Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('The Works', (SELECT id FROM genres WHERE name = 'Pop Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('A Kind of Magic', (SELECT id FROM genres WHERE name = 'Hard Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('The Miracle', (SELECT id FROM genres WHERE name = 'Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('Innuendo', (SELECT id FROM genres WHERE name = 'Hard Rock'), (SELECT id FROM singers WHERE name = 'Queen')),
('Made in Heaven', (SELECT id FROM genres WHERE name = 'Rock'), (SELECT id FROM singers WHERE name = 'Queen'))
;

INSERT INTO albums (title, genreId, singerId) VALUES
('Abbey Road', (SELECT id FROM genres WHERE name = 'Rock'), (SELECT id FROM singers WHERE name = 'The Beatles'))
;

-- Song: (.+), (.+)
-- \('$1', '$2', \(SELECT id FROM albums WHERE title = 'Queen'\)\),

INSERT INTO songs (title, duration, albumId) VALUES
('Keep Yourself Alive', '3:15', (SELECT id FROM albums WHERE title = 'Queen')),
('Doing All Right', '4:09', (SELECT id FROM albums WHERE title = 'Queen')),
('Great King Rat', '5:42', (SELECT id FROM albums WHERE title = 'Queen')),
('My Fairy King', '4:07', (SELECT id FROM albums WHERE title = 'Queen')),
('Liar', '6:25', (SELECT id FROM albums WHERE title = 'Queen')),
('The Night Comes Down', '4:23', (SELECT id FROM albums WHERE title = 'Queen')),
('Modern Times Rock ''N'' Roll', '1:48', (SELECT id FROM albums WHERE title = 'Queen')),
('Son And Daughter', '3:18', (SELECT id FROM albums WHERE title = 'Queen')),
('Jesus', '3:45', (SELECT id FROM albums WHERE title = 'Queen')),
('Seven Seas Of Rhye', '1:08', (SELECT id FROM albums WHERE title = 'Queen'))
;

INSERT INTO songs (title, duration, albumId) VALUES
('Come Together', '4:19', (SELECT id FROM albums WHERE title = 'Abbey Road'))
;