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
	Apple apple;
	void HandleInput();
	void Update();
	bool key_up = false, key_down = false, key_right = false, key_left = false;
};

