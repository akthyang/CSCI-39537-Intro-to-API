# CSCI-39537-Intro-to-API - Final Project - Book API

My final project is to create a Book API holding informations for some light novels. The initial plan of my final project can be found in my [PPT presentation](https://github.com/akthyang/CSCI-39537-Intro-to-API/blob/d270cd0dc63f693939236eb7c942aaff32f26037/Book%20API%20-%20Lightnovels.pdf). The information that was added to my database was found by using [Google](https://www.google.com/) and [NovelUpdates](https://www.novelupdates.com/)

## Database

### ER Diagram of Initial Plan for API
<img src="PreviousERDiagram.png" alt="This is the ER diagram for my database before any changes were made" width="700px" height="500px">

### ER Diagram for Final API
<img src="ERDiagram.png" alt="ER diagram for final version of API" width="500px" height="500px">

### Sql Code used to Create Database
```
CREATE DATABASE Lightnovels;

USE Lightnovels;

CREATE TABLE Novels (
    NovelId INT NOT NULL AUTO_INCREMENT,
    Title VARCHAR(1000) NOT NULL,
    OriginalLanguage VARCHAR(1000) NOT NULL,
    Blurb VARCHAR(4000) NOT NULL,
    Rating DECIMAL(4, 2) NULL,
    Genre VARCHAR(1000) NOT NULL,
    TranslatedStatus ENUM('ongoing', 'completed', 'hiatus'),
    Link VARCHAR(1000) NULL,
    PRIMARY KEY (NovelId)
); 

CREATE TABLE Comics (
    ComicId INT NOT NULL AUTO_INCREMENT,
    Title VARCHAR(1000) NOT NULL,
    Link VARCHAR(1000) NULL,
    PRIMARY KEY (ComicId)
);

CREATE TABLE Raw (
    RawId INT NOT NULL AUTO_INCREMENT,
    Title VARCHAR(1000) NOT NULL,
    Link VARCHAR(1000) NOT NULL,
    BookStatus VARCHAR(500) NULL,
    PRIMARY KEY (RawId)
);

CREATE TABLE Creators (
    CreatorId INT NOT NULL AUTO_INCREMENT,
    EnglishName VARCHAR(1000) NULL,
    FullName VARCHAR(1000) NOT NULL,
    PRIMARY KEY (CreatorId)
);

ALTER TABLE Novels ADD COLUMN ComicId INT;
ALTER TABLE Novels ADD CONSTRAINT FK_NovelComic FOREIGN KEY (ComicId) References Comics(ComicId);
ALTER TABLE Novels ADD COLUMN RawId INT;
ALTER TABLE Novels ADD CONSTRAINT FK_NovelRaw FOREIGN KEY (RawId) References Raw(RawId);
ALTER TABLE Novels ADD COLUMN CreatorId INT;
ALTER TABLE Novels ADD CONSTRAINT FK_NovelCreator FOREIGN KEY (CreatorId) References Creators(CreatorId);
```

### Information added to the Database - more information can be found in the csv files uploaded for each database
Please note all csv files were directly exported from mySQL workbench and the N/A or Unknown field in some data was added just in case this information
did not exist for the novel or this information was not known.

#### Comic
![Image of the Database for Comics](ComicDatas.png)

#### Creator
![Image of the Database for Creators](CreatorDatas.png)

#### Raw
![Image of the Database for Raw](RawDatas.png)

#### Sample of Novel Data
![Image of a part of the Database for Novel](NovelData.png)

## API endpoints and HTTP methods
### Please note: My API does not need PostMan or similar applications to run as these methods have been built into the application itself. Please use the website to modify any data as some HTTP methods that work on the website may not work on PostMan.

![GET method for database](get.jpg)
* returns all the novels in the database and displays it as a table 

![GET method for NovelId](getID.jpg)
* gets the information for NovelId 2, please note 2 can be replaced by any other number

![POST method that creates a new novel in the database](postCreate.jpg)
* creates a new novel in the database

![GET method that asks user for the information for the new novel](getCreate.jpg)
* the GET method for the same API endpoint will return the webpage that asks user to enter information for the new novel

![PUT method that updates the information for a novel](putEditId.jpg)
* updates the information for a novel in the database with NovelId 5, note 5 can be replaced by other numbers

![GET method asks user for the information that needs to be updated into the database](getEditId.jpg)
* the GET method for the same API endpoint will return the webpage that asks user the user to put in the data that needs to be updated into the database

![DELETE method that deletes a novel from the database](DeleteId.jpg)
* deletes the novel with NovelId 5 from the database, note 5 can be replaced by other numbers

![GET method that asks user if they want to delete the novel](getDeleteId.jpg)
* the GET method for the same API endpoint returns a page that asks user if they want to delete this novel

## BookAPI - How Does it Look?
### HomePage
![Image of HomePage of API](HomePage.jpg)

### BookAPI - GET method for all novels
![Image of Novel Database](BookAPI.jpg)

### GET method of one novel
![Image of GET method for one novel](Details.jpg)

### POST method for adding new novel
![Image of page asking to enter info for new novel](Create.jpg)
#### After submitting data to create new novel, please press button to go back
![Image of page after novel was created](Created.jpg)

### PUT method
![Image of how editing the database looks like](Edit.jpg)
#### After submitting changes, please press the button to go back to List
![Image of database after edit was submitted](Edited.jpg)

### Delete method
![Image of page asking if you want to delete](Delete.jpg)
#### After deleting, please press the button to go back
![Image of page after deleting](Deleted.jpg)

