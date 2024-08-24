/* Elementen toevoegen aan tabellen */

/* Souveniers */
INSERT INTO Souveniershop.Souvenier (naam, beschrijving)
VALUES
    ('Eiffel Tower Miniature', 'A small metal replica of the iconic Eiffel Tower, perfect for displaying on a shelf or desk.'),
    ('Venetian Mask', 'An ornate, hand-painted mask that captures the mystique of Venice''s Carnival.'),
    ('New York City Snow Globe', 'A glass snow globe featuring famous New York City landmarks, ideal for collecting or gifting.'),
    ('Taj Mahal Keychain', 'A keychain with a detailed miniature Taj Mahal, a symbol of India''s architectural beauty.'),
    ('London Double-Decker Bus Model', 'A die-cast model of London''s red double-decker bus, a symbol of the city''s transportation.'),
    ('Egyptian Hieroglyphics Papyrus', 'An authentic papyrus scroll with ancient Egyptian hieroglyphics for history enthusiasts.'),
    ('Tokyo Cherry Blossom Fan', 'A delicate fan adorned with cherry blossoms, a symbol of springtime in Tokyo.'),
    ('Sydney Opera House Magnet', 'A magnetic souvenir showcasing the unique architecture of the Sydney Opera House.'),
    ('Greek Mythology Bookmarks', 'Set of bookmarks featuring characters from Greek mythology, perfect for book lovers.'),
    ('Mexican Talavera Pottery', 'Colorful, hand-painted pottery from Mexico, great for adding a touch of art to your home.'),
    ('Amsterdam Canal House Figurine', 'A miniature replica of an Amsterdam canal house, representing Dutch architecture.'),
    ('Hawaiian Hula Dancer Dashboard Doll', 'A dashboard doll of a hula dancer, a popular symbol of Hawaiian culture and dance.'),
    ('Machu Picchu Postcard Set', 'A postcard set with stunning images of Machu Picchu, the Incan citadel in Peru.'),
    ('African Safari Wooden Mask', 'A hand-carved wooden mask representing African tribal art and traditions.'),
    ('Russian Matryoshka Nesting Dolls', 'A set of nesting dolls, each one fitting inside the other, hand-painted with Russian themes.'),
    ('Spanish Flamenco Hand Fan', 'A hand-held fan with intricate Spanish flamenco designs, ideal for staying cool.'),
    ('Canadian Maple Leaf Lapel Pin', 'A lapel pin in the shape of a maple leaf, a symbol of Canada''s natural beauty.'),
    ('Chinese Calligraphy Scroll', 'A scroll with traditional Chinese calligraphy, perfect for art and culture enthusiasts.'),
    ('Swiss Alpine Cow Bell', 'A metal cowbell from the Swiss Alps, a classic souvenir with a charming sound.'),
    ('Brazilian Carnival Mask', 'A vibrant mask inspired by the Brazilian Carnival, full of colors and festive spirit')


/* Verkoper */
INSERT INTO Souveniershop.Verkoper (voornaam, naam)
VALUES
    ('Smith', 'Johnson'),
    ('Brown', 'Davis'),
    ('Lee', 'Chen'),
    ('Garcia', 'Martinez'),
    ('Kim', 'Park'),
    ('Müller', 'Schmidt'),
    ('López', 'Rodríguez'),
    ('Patel', 'Shah'),
    ('Williams', 'Jones'),
    ('González', 'López'),
    ('Nguyen', 'Tran'),
    ('Santos', 'Silva'),
    ('Hernandez', 'Gomez'),
    ('O''Connor', 'Murphy'),
    ('Sato', 'Suzuki'),
    ('Wilson', 'Taylor'),
    ('Martinez', 'Gonzalez'),
    ('Chen', 'Wang'),
    ('Taylor', 'Miller'),
    ('Harris', 'Clark')


/* Plaats */
INSERT INTO Souveniershop.Plaats (naam, beschrijving)
VALUES
    ('Paris, France', 'The romantic city of Paris, known for the Eiffel Tower and delicious pastries.'),
    ('Venice, Italy', 'A picturesque city of canals, famous for gondola rides and beautiful architecture.'),
    ('New York City, USA', 'The bustling metropolis with iconic landmarks like Times Square and Central Park.'),
    ('Agra, India', 'Home to the magnificent Taj Mahal, a symbol of eternal love.'),
    ('London, United Kingdom', 'The capital of England with a rich history and the iconic Big Ben.'),
    ('Cairo, Egypt', 'The city of the pyramids, known for its ancient history and culture.'),
    ('Tokyo, Japan', 'A vibrant and modern city with a rich blend of tradition and technology.'),
    ('Sydney, Australia', 'The stunning city with the Sydney Opera House and beautiful beaches.'),
    ('Athens, Greece', 'The birthplace of democracy and ancient ruins like the Acropolis.'),
    ('Mexico City, Mexico', 'A cultural hub with vibrant markets and delicious street food.'),
    ('Amsterdam, Netherlands', 'Known for its picturesque canals and historic architecture.'),
    ('Honolulu, Hawaii', 'A tropical paradise with beautiful beaches and hula dancers.'),
    ('Machu Picchu, Peru', 'The ancient Incan citadel nestled in the Andes mountains.'),
    ('Nairobi, Kenya', 'A gateway to African safaris with diverse wildlife and national parks.'),
    ('Moscow, Russia', 'The capital city with the iconic Red Square and St. Basil''s Cathedral.'),
    ('Seville, Spain', 'A city known for flamenco dancing, beautiful architecture, and delicious tapas.'),
    ('Toronto, Canada', 'A multicultural city with the impressive CN Tower and cultural diversity.'),
    ('Beijing, China', 'The capital of China, rich in history and home to the Great Wall.'),
    ('Zurich, Switzerland', 'A picturesque city in the Swiss Alps with a strong banking sector.'),
    ('Rio de Janeiro, Brazil', 'Famous for its lively Carnival and stunning beaches like Copacabana.')


/* VerkoperPlaats */
INSERT INTO Souveniershop.VerkoperPlaats (verkoperID, plaatsID, datum)
VALUES
    (1, 1, '2023-01-05'),
    (2, 2, '2023-02-12'),
    (3, 3, '2023-03-20'),
    (4, 4, '2023-04-08'),
    (5, 5, '2023-05-15'),
    (6, 6, '2023-06-22'),
    (7, 7, '2023-07-30'),
    (8, 8, '2023-08-03'),
    (9, 9, '2023-09-17'),
    (10, 10, '2023-10-11'),
    (11, 11, '2023-11-28'),
    (12, 12, '2023-12-19'),
    (13, 13, '2024-01-14'),
    (14, 14, '2024-02-27'),
    (15, 15, '2024-03-08'),
    (16, 16, '2024-04-01'),
    (17, 17, '2024-05-09'),
    (18, 18, '2024-06-16'),
    (19, 19, '2024-07-25'),
    (20, 20, '2024-08-29')


/* SouvenierPlaats */
INSERT INTO Souveniershop.SouvenierPlaats (souvenierID, plaatsID, prijs)
VALUES
    (1, 1, 9.99),
    (2, 2, 14.99),
    (3, 3, 24.95),
    (4, 4, 19.99),
    (5, 5, 29.99),
    (6, 6, 8.95),
    (7, 7, 12.50),
    (8, 8, 34.99),
    (9, 9, 7.99),
    (10, 10, 16.99),
    (11, 11, 11.49),
    (12, 12, 21.99),
    (13, 13, 15.75),
    (14, 14, 27.99),
    (15, 15, 9.99),
    (16, 16, 18.50),
    (17, 17, 10.99),
    (18, 18, 22.95),
    (19, 19, 19.99),
    (20, 20, 13.75)


/* Verkoop */
INSERT INTO Souveniershop.Verkoop (verkoperplaatsID, souvenierplaatsID, aantal)
VALUES
    (1, 1, 10),
    (2, 2, 15),
    (3, 3, 22),
    (4, 4, 13),
    (5, 5, 18),
    (6, 6, 8),
    (7, 7, 30),
    (8, 8, 15),
    (9, 9, 10),
    (10, 10, 18),
    (11, 11, 11),
    (12, 12, 27),
    (13, 13, 9),
    (14, 14, 21),
    (15, 15, 15),
    (16, 16, 30),
    (17, 17, 12),
    (18, 18, 20),
    (19, 19, 16),
    (20, 20, 11)