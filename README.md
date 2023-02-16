# Activity 5 - WebAPIClient

Based on the code given during the lecture on Feb. 14, 2023, please call another API and present to the user by printing to console/terminal at least 3 pieces of information. They must be presented in an instance of class or classes.

## Genderize
After looking through the APIs available in [Documenter](https://documenter.getpostman.com/view/8854915/Szf7znEe#8279640c-f026-47a5-9261-ecbdf82d96f0), I chose the [Genderize API](https://genderize.io/) API for this assignment.
Link used was:
```
https://api.genderize.io/?name=person
```
where person is the name of a person
### Example of Expected Output For my Program 
```
Enter a Name.
Alex
---
Name of Person: alex
Gender: male
How many people with this name: 1114390
Probability of a person being named this name: 0.96

---
Enter a Name.
Sakura
---
Name of Person: sakura
Gender: female
How many people with this name: 3689
Probability of a person being named this name: 0.97

---
Enter a Name.
Jiahui
---
Name of Person: jiahui
Gender: female
How many people with this name: 107
Probability of a person being named this name: 0.81

---
Enter a Name.
Kevin
---
Name of Person: kevin
Gender: male
How many people with this name: 932165
Probability of a person being named this name: 1

---
Enter a Name.
Tommy
---
Name of Person: tommy
Gender: male
How many people with this name: 133736
Probability of a person being named this name: 1
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
