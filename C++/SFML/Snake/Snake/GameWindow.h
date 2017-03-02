#pragma once
#include "Window.h"
#include "Snake.h"
#include <iostream>
class GameWindow
{
	public:
	GameWindow(sf::VideoMode& vm, const std::string& title);
	~GameWindow();

	private:
	Window gameWindow;
	Snake snake;
	void HandleInput();
	void Update();
};

