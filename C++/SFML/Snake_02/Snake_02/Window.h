#pragma once
#include <iostream>
#include <SFML\Graphics.hpp>
#include "Apple.h"
class Window
{
public:
	Window(const sf::VideoMode vm, const std::string& title);
	~Window();

	const sf::Vector2u& GetSize();
	sf::RenderWindow* GetWindow();
	void HandleInput(sf::Event* e);
	void Render();
	void Update();

private:
	sf::RenderWindow window;
	Apple apple;
};

