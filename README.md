# Casino Simulation
A WPF Desktop Application with Blackjack, Roulette and Slots mini-games.

## Description
This casino simulation allows players to cash in and hit the casino
floor, with options to play one of several casino activities.
Players are immersed into a realistic casino, complete with 2D
animations, graphical poker chips and authentic casino rules.

Casino Simulation is a WPF application that uses C# for the back end
and XAML for the GUI. 

## Installation
You can download the latest version here:
https://github.com/stcarlton/CasinoSimulation/releases/download/v1.0/CasinoSimulation.exe

## Design
![Capture](https://user-images.githubusercontent.com/58635162/193425182-56249462-9aaf-4f2a-bc0a-8f92dbbd5877.JPG)
Source Code architecture follows MVVM design pattern.

## How to Use

### Menu
![CasinoMenu](https://user-images.githubusercontent.com/58635162/193424580-2af986cd-1ddd-4728-81a9-d0db92bcffd6.jpg)
* Menu button will return to this window at any time
* Press the Cash In button to receive an initial $5000 in chips
* The chip total is displayed in the bottom left corner
* Select stakes Low, Mid, High or VIP to adjust minimum and maximum bet limits
* Select from Blackjack, Roulette or Slots games
* Cash Out Exits the game

### Blackjack
![CasinoBlackjack](https://user-images.githubusercontent.com/58635162/193424623-038cd9a1-94a1-48c4-af65-49a1ee998805.jpg)
* Betting
    * Click on Chips to increase bet
    * Click on chip stack to decrease bet
    * Press the deal button
* Option
    * Press Hit to receive new card
    * Press Double Down to double bet (must be on 9, 10 or 11)
    * Press Split to split hand (cards must have equal value)
    * Press Buy Insurance (dealer must show an ace)
    * Press Stand
* Resolution
    * Press next hand to cycle through the result of each hand and see winnings
    * When all hands have been resolved, circle back to Betting

### Roulette
![CasinoRoulette](https://user-images.githubusercontent.com/58635162/193424903-075beed2-0376-4e75-94ea-2f143108514d.jpg)
* Click on bet position to choose what to bet on
* Click on chips to increase bet on bet position
* Click on chip stack to decrease bet
* Repeat until all bets are placed
* Press Spin

### Slots
![CasinoSlots](https://user-images.githubusercontent.com/58635162/193424911-33215115-9b28-43e1-a646-1fc31e1e52e0.jpg)
* Click on Bet Table to see payouts
* Click on Bet Max to change bet to maximum
* Click on Bet One to change bet to one
* Click on Spin

### Contributions
* Seth Carlton developed the code for the Menu and Blackjack games, and created all design diagrams.
* Eric Piccard contributed the code for the Roulette and Slots games.
