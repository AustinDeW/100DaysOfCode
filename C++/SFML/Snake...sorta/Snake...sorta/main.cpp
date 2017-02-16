#include <SFML\Graphics.hpp>
#include <random>
#include <ctime>
#include <iostream>

bool playerGrabbedTreasure(sf::RectangleShape* player, sf::RectangleShape* treasure);
sf::Vector2f randomTreasurePosition(sf::RenderWindow*);

int main()
{
	srand(time(NULL));
	sf::RenderWindow window(sf::VideoMode(680, 340), "Snake...sorta");
	window.setFramerateLimit(60);

	float speed = 10;
	sf::Vector2f rectPosition(50, 50);
	sf::RectangleShape rectangle(sf::Vector2f(25, 25));
	rectangle.setOrigin(rectangle.getSize().x / 2, rectangle.getSize().y / 2);
	rectangle.setFillColor(sf::Color(255, 0, 0));

	sf::Vector2f treasurePosition(randomTreasurePosition(&window));
	sf::RectangleShape treasure(sf::Vector2f(10,10));
	treasure.setOrigin(2.5f, 2.5f);
	treasure.setPosition(treasurePosition);
	treasure.setFillColor(sf::Color(0, 0, 255));

	int score = 0;
	sf::Font fontSith;
	fontSith.loadFromFile("C:/Users/austin/Documents/GitHub/C++/SFML/Snake...sorta/Snake...sorta/Data/Roboto/Roboto-Regular.ttf");
	sf::Text txtScore(std::to_string(score),fontSith);
	txtScore.setPosition(340, 0);
	txtScore.setCharacterSize(30);
	txtScore.setStyle(sf::Text::Bold);
	txtScore.setFillColor(sf::Color::Black);

	while (window.isOpen())
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
			{
				window.close();
			}

			//if (event.type == sf::Event::MouseMoved)
			//{
			//	std::cout << event.mouseMove.x << "," << event.mouseMove.y << std::endl;
			//}

			if (event.type == sf::Event::KeyPressed)
			{
				switch (event.key.code)
				{
					case sf::Keyboard::Up:
						rectPosition.y -= speed;
						break;
					case sf::Keyboard::Right:
						rectPosition.x += speed;
						break;
					case sf::Keyboard::Down:
						rectPosition.y += speed;
						break;
					case sf::Keyboard::Left:
						rectPosition.x -= speed;
						break;
				}
			}
		}

		//Logic
		if ((rectangle.getPosition().x + rectangle.getSize().x / 2) > window.getSize().x)
		{
			rectPosition.x -= 5;
		}
		else if ((rectangle.getPosition().x - rectangle.getSize().x / 2) < 0)
		{
			rectPosition.x += 5;
		}

		if ((rectangle.getPosition().y + rectangle.getSize().y / 2) > window.getSize().y)
		{
			rectPosition.y -= 5;
		}
		else if ((rectangle.getPosition().y - rectangle.getSize().y / 2) < 50)
		{
			rectPosition.y += 5;
		}

		if (playerGrabbedTreasure(&rectangle, &treasure))
		{
			treasure.setPosition(randomTreasurePosition(&window));
			txtScore.setString(std::to_string(++score));
		}

		rectangle.setPosition(rectPosition);

		//Render
		window.clear(sf::Color(244, 244, 244));

		//Draw
		window.draw(rectangle);
		window.draw(treasure);
		window.draw(txtScore);

		window.display();
	}

	return 0;
}

bool playerGrabbedTreasure(sf::RectangleShape* player, sf::RectangleShape* treasure)
{
	if ( player->getPosition().x + player->getSize().x / 2 > treasure->getPosition().x - treasure->getSize().x / 2 &&
		 player->getPosition().x - player->getSize().x / 2 < treasure->getPosition().x + treasure->getSize().x / 2 &&
		 player->getPosition().y + player->getSize().y / 2 > treasure->getPosition().y - treasure->getSize().y / 2 &&
		 player->getPosition().y - player->getSize().y / 2 < treasure->getPosition().y + treasure->getSize().y / 2 )
	{
		return true;
	}

	return false;
}

sf::Vector2f randomTreasurePosition(sf::RenderWindow* window)
{
	return sf::Vector2f(rand() % window->getSize().x - 10, rand() % window->getSize().y + 50);
}