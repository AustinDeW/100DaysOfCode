#include <SFML\Graphics.hpp>
#include <random>
#include <ctime>

sf::Vector2f randomTreasurePosition(sf::RenderWindow*);

int main()
{
	srand(time(NULL));
	sf::RenderWindow window(sf::VideoMode(680, 340), "SFML_Practice_01");

	float speed = 10;
	sf::Vector2f rectPosition(50, 50);
	sf::RectangleShape rectangle(sf::Vector2f(25, 25));
	rectangle.setOrigin(rectangle.getSize().x / 2, rectangle.getSize().y / 2);
	rectangle.setFillColor(sf::Color(255, 0, 0));

	sf::Vector2f treasurePosition(0, 0);
	sf::CircleShape treasure(5, 10);
	treasure.setOrigin(2.5f, 2.5f);
	treasure.setFillColor(sf::Color(0, 0, 255));

	while (window.isOpen())
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
			{
				window.close();
			}

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
		else if ((rectangle.getPosition().y - rectangle.getSize().y / 2) < 0)
		{
			rectPosition.y += 5;
		}

		rectangle.setPosition(rectPosition);
		treasure.setPosition(randomTreasurePosition(&window));

		//Render
		window.clear(sf::Color(244, 244, 244));

		//Draw
		window.draw(rectangle);
		window.draw(treasure);

		window.display();
	}

	return 0;
}

sf::Vector2f randomTreasurePosition(sf::RenderWindow* window)
{
	return sf::Vector2f(rand() % window->getPosition().x, rand() % window->getPosition().y);
}