#include "Game.h"
#include <iostream>

int main()
{
	std::cout << "1) 1 Player\n2) 2 Players\nOption: ";
	char option = '\0';
	std::cin >> option;
	if (std::cin.good())
	{
		Game game(sf::VideoMode(800, 600), "Pong", option == '2' ? 2 : 1);
		while (game.GetWindow()->isOpen())
		{
			game.HandleInput();
			game.Update();
			game.Render();
		}
	}
	else
	{
		std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		std::cin.clear();
		std::cout << "Error selection is invalid" << std::endl;
	}

	return 0;
}