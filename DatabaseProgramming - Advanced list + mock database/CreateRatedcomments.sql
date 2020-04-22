use School;

DROP TABLE IF EXISTS
	ratedcomments;
    
CREATE TABLE ratedcomments (
	id int(11) AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL,
    email varchar(30) NOT NULL,
    comment text NOT NULL,
    reg_date TIMESTAMP,
    rating int(11) NOT NULL
);

INSERT INTO ratedcomments (name, email, comment, rating) VALUES
('Kalle Kvist', 'kalle@hotmail.com', 'A bad penny always turns up.', 1),
('Arne Anka', 'arnis@hemnet.se', 'A barking dog never bites.', 4),
('Gunnar Gren', 'gogge@gmail.com', 'A bird in the hand is worth two in the bush. A cat may look at a king.', 5),
('Krille Krokodil', 'krille@yahoo.se', 'A change is as good as a rest. A dog is a mans best friend.', 3),
('Sune Sundin', 'a@b.com', 'A drowning man will clutch at a straw.', 4),
('Kajsa Kavat', 'kajsa@facebook.nu', 'A fish always rots from the head down.', 1),
('Gunnar Gren', 'gogge@gmail.com', 'A fool and his money are soon parted.', 5),
('Big Red One', 'big@gmail.com', 'A friend in need is a friend indeed. A golden key can open any door.', 4),
('Kattis Mok', 'cat@apple.co.uk', 'A good beginning makes a good ending. A good man is hard to find.', 3),
('Krille Krokodil', 'krille@yahoo.se', 'Children and fools tell the truth', 5),
('Kalle Kvist', 'kalle@hotmail.com', 'A person is known by the company he keeps.', 1),
('Sune Sundin', 'a@b.com', 'A journey of a thousand miles begins with a single step.', 4),
('Max Power', 'max@gmail.com', 'A leopard cannot change its spots. A little knowledge is a dangerous thing. A little learning is a dangerous thing.', 5),
('Svenne Rubin', 'Sr@rubins.se', 'A man who is his own lawyer has a fool for his client.', 1),
('Karl Pedal', 'kalp@cnn.com', 'A new broom sweeps clean.', 4),
('Sara Svensson', 'ss@twenty.com', 'A nods as good as a wink to a blind horse. A penny saved is a penny earned.', 1),
('Helga Helmin', 'hh@yahoo.com', 'A picture paints a thousand words.', 2),
('Krille Krokodil', 'krille@yahoo.se', 'A place for everything and everything in its place.', 3),
('Kalle Kvist', 'kalle@hotmail.com', 'A poor workman always blames his tools.', 3),
('Gunnar Gren', 'gogge@gmail.com', 'A problem shared is a problem halved. A prophet is not recognized in his own land.', 5);