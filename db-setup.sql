USE moonminer2;

-- CREATE TABLE testgame (
--   id int NOT NULL AUTO_INCREMENT,
--   playerName VARCHAR(255) NOT NULL,
--   profileImg VARCHAR(255) NOT NULL,
--   playerMoney int DEFAULT 1000,
--   playerEnergy int DEFAULT 100,
--   playerTool VARCHAR(255) DEFAULT 'Wood Pickaxe',
--   resource1 int DEFAULT 1000,
--   resource2 int DEFAULT 1000,
--   resource3 int DEFAULT 0,
--   resource4 int DEFAULT 0,
--   planetId int DEFAULT 1,
--   PRIMARY KEY (id)
-- )

-- CREATE Table testplanets (
--   id int NOT NULL AUTO_INCREMENT,
--   planetName VARCHAR(255) NOT NULL,
--   moneyNeeded int NOt NULL,
--   expiditionCost int NOT NULL,
--   resource1 int NOT NULL,
--   resource2 int NOT NULL,
--   resource3 int NOT NULL,
--   resource4 int NOT NULL,
--   isLocked BOOLEAN NOT NULL,
--   planetImg VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- )

-- INSERT INTO testplanets (planetName, moneyNeeded, expiditionCost, resource1, resource2, resource3, resource4, isLocked, planetImg) VALUES ("Planet One", 0, 20, 1, 3, 5, 10, 0, "https://space-facts.com/wp/wp-content/uploads/mercury-transparent.png");
-- INSERT INTO testplanets (planetName, moneyNeeded, expiditionCost, resource1, resource2, resource3, resource4, isLocked, planetImg) VALUES ("Planet Two", 100, 35, 1, 10, 20, 30, 1,"http://pngimg.com/uploads/mars_planet/mars_planet_PNG34.png" );
-- INSERT INTO testplanets (planetName, moneyNeeded, expiditionCost, resource1, resource2, resource3, resource4, isLocked, planetImg) VALUES ("Planet Three", 250, 50, 10, 25, 40, 75, 1, "https://www.pngmart.com/files/3/Space-Planet-PNG-Transparent-Image.png");
-- INSERT INTO testplanets (planetName, moneyNeeded, expiditionCost, resource1, resource2, resource3, resource4, isLocked, planetImg) VALUES ("Planet Four", 500, 75, 25, 50, 100, 150, 1, "https://space-facts.com/wp/wp-content/uploads/venus-transparent.png");


-- DROP TABLE IF EXISTS testgame;
-- DROP TABLE IF EXISTS testplanets;
-- DELETE FROM testgame;
-- DELETE FROM testplanets;