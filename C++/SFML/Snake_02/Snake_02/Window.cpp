#include "Window.h"

Window::Window(const sf::VideoMode vm, const std::string & title)
	: window(vm, title)
{
	window.setFramerateLimit(60);

	// Initialize Apple
	apple.SetRadius(10.0f);
	apple.Spawn(window.getSize());

	while (window.isOpen())
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			HandleInput(&event);
		}

		Render();
		Update();
	}
}

Window::~Window()
{
}

const sf::Vector2u& Window::GetSize()
{
	return window.getSize();
}

sf::RenderWindow* Window::GetWindow()
{
	return &window;
}

void Window::HandleInput(sf::Event* e)
{
	if (e->type == sf::Event::Closed)
	{
		window.close();
	}
	else if (e->type == sf::Event::KeyPressed)
	{
		switch (e->key.code)
		{
			case sf::Keyboard::Escape:
				window.close();
				break;
		}
	}
}

void Window::Render()
{
	window.clear(sf::Color::Black);

	window.draw(apple.GetDrawable_Apple());

	window.display();
}

void Window::Update()
{
	apple.Spawn(window.getSize());
}
