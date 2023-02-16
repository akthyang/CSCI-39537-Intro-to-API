# Activity 5 - WebAPIClient

Based on the code given during the lecture on Feb. 14, 2023, please call another API and present to the user by printing to console/terminal at least 3 pieces of information. They must be presented in an instance of class or classes.

## Genderize
After looking through the APIs available in [Documenter](https://documenter.getpostman.com/view/8854915/Szf7znEe#8279640c-f026-47a5-9261-ecbdf82d96f0), I chose the [Genderize API](https://genderize.io/) API for this assignment. This API predicts and assigns a gender to the name entered into terminal.
Link used was:
```
https://api.genderize.io/?name=person
```
where person is the name of a person
### Example of Expected Output For my Program 
```
Enter a Name. To exit, just press enter. Do not enter any input.
Kevin
---
Name of Person: kevin
Gender: male
Number of Data Examined to Predict Outcome: 932165
Certainty of Assigned Gender: 1

---
Enter a Name. To exit, just press enter. Do not enter any input.
Amy
---
Name of Person: amy
Gender: female
Number of Data Examined to Predict Outcome: 480005
Certainty of Assigned Gender: 1

---
Enter a Name. To exit, just press enter. Do not enter any input.
Jiahui
---
Name of Person: jiahui
Gender: female
Number of Data Examined to Predict Outcome: 107
Certainty of Assigned Gender: 0.81

---
Enter a Name. To exit, just press enter. Do not enter any input.
Kirito
---
Name of Person: kirito
Gender: male
Number of Data Examined to Predict Outcome: 28
Certainty of Assigned Gender: 1

```

## Pokemon
During class, the teacher provided an example with how we can call an API by using the [Pokemon API](https://pokeapi.co/). 
Link used was:
```
https://pokeapi.co/api/v2/pokemon/name/
```
where name is the name of a pokemon
### Expected Output
```
---
Pokemon #2
Name: ivysaur
Weight: 130lb
Height: 10ft
Types(s):
 grass poison
---
Enter Pokemon name. Press Enter without writing a name to quit the program.
pikachu
---
Pokemon #25
Name: pikachu
Weight: 60lb
Height: 4ft
Types(s):
 electric
---
Enter Pokemon name. Press Enter without writing a name to quit the program.
acreus
ERROR. Please enter a valid Pokemon name
Enter Pokemon name. Press Enter without writing a name to quit the program.
arceus
---
Pokemon #493
Name: arceus
Weight: 3200lb
Height: 32ft
Types(s):
 normal
```
