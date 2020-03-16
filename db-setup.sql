USE moonminer2;

-- CREATE TABLE testing (
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- )

CREATE TABLE testgame (
  id int NOT NULL AUTO_INCREMENT,
  playerName VARCHAR(255) NOT NULL,
  profileImg VARCHAR(255) NOT NULL,
  playerMoney int DEFAULT 0,
  PRIMARY KEY (id)
)