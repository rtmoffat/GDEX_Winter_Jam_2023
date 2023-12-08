// To make smooth animations later on we are setting up a variable called target_x.
// The object will always approach this position in the step event.
target_x = x;

// As above, we also need to set a target_y variable.
// target_x and target_y start at the same values as the
// object's x and y positions in the room.
target_y = y;

// This variable tells the object if it's currently part of
// a matching set. It will be updated and reset each time
// a player makes a move.
currently_matched = 0;

// This variable keeps track of whether or not the object
// fell into an empty space this turn. We keep track of this
// so we can check for matches and the player can build combos
// when falling blocks also make groups of three.
fell_this_turn = 0;

// Created a variable to store the id of a piece which swaps
// with this one. The variable starts with the value "noone"
// which is a keyword in GameMaker that will never match
// a real instance's id.
swap_parent = noone;

// We are using the same sprite for all matching pieces,
// but using different subimages. We set the 
// animation speed to 0 to stop the object from cycling
// through each image.
image_speed = 0;

// Set the available piece types depending on the room.
switch(room)
{
	case rm_level_1:
		image_index = floor(random_range(0, 6));
		break;

	case rm_level_2:
		image_index = floor(random_range(0, 7));
		break;

	case rm_level_3:
		image_index = floor(random_range(0, 8));
		break;
}

// Set the instance alpha to 0, we will gradually increase it
// in the step event.
image_alpha = 0;

// Create a variable called draw_squish.
// We use this to draw the effect of the pieces "squishing" when
// they fall into place.
draw_squish = 1;

// Create a variable called draw_squish_target.
// We use this to draw the effect of the pieces "squishing" when
// they fall into place.
draw_squish_target = 1;

// Create a random number and assign it to a temporary variable
// called _y_offset_randomiser. We will multiply this by -10
// in the next action and assign it to the variable draw_y_offset.
// Adding this random element to the y offset will make the
// pieces appear to fall into place more naturally.
var _y_offset_randomiser = floor(random_range(1, 10 + 1));

// Create a variable called draw_y_offset.
// We use this to offset the y at which the object is drawn when it
// is first created.
draw_y_offset = -10*_y_offset_randomiser;

// See scripts >> check_on_startup
// This function checks to see if this piece would create
// a line of three at the start of the game, and if so it
// changes the type of piece until it will no longer create a match.
// NOTE: This script would permanently freeze the game if
// you were using too few types of matching pieces.
check_on_startup();

check_for_matches = function()
{
	// When triggered we call user event 0
	// which checks for matches.
	// They take place in a user event because they 
	// are sometimes called from obj_controller.
	event_user(0);	
}

check_drag = function(_drag_horizontal, _drag_vertical)
{
	// Check if player is in any kind of menu and ends event if it is
	if((instance_exists(obj_game_pause)) || (instance_exists(obj_game_over_lose)) || (instance_exists(obj_game_over_win)) || (instance_exists(obj_no_valid_matches)))
	exit;

	// Check if the player is allowed to swap the pieces.
	// They are not allowed while the game is calculating
	// the result of their previous move, for example.
	if(global.can_swap == 1)
	{
		// The player dragged this matching piece one square to the right
		if(_drag_horizontal > sprite_width / 2)
		{
			// Check if there is a piece on the playfield
			// one square to the right of the piece currently
			// being dragged.
			// If yes, assign the id of the piece we want to
			// swap with to a temporary variable called
			// _piece_to_swap.
			var _piece_to_swap = collision_point(x + sprite_width, y, obj_matching_piece, true, 1);
			if((_piece_to_swap))
			{
				// Play a sound effect indicating that the
				// pieces are being swapped.
				audio_play_sound(snd_piece_swap, 0, 0);
		
				// Set the current piece to move to the right
				// by updating the target_x variable which
				// the piece will approach in the step event
				target_x += sprite_width;
		
				// Tell the piece we're swapping with to move
				// to the left by updating the target_x variable which
				// the piece will approach in its step event
				_piece_to_swap.target_x -= _piece_to_swap.sprite_width;
		
				// Tell the piece we're swapping with which piece
				// forced it to swap by changing its swap_parent
				// variable to the id of this instance
				_piece_to_swap.swap_parent = id;
		
				// For this piece, set the variable swap_parent to the id
				// of the _piece_to_swap so that we can use it later
				swap_parent = _piece_to_swap;
		
				// The player performed a valid move and the game will
				// now need to calculate the result of that move before
				// we let the player move again.
				// Here we set the global variable can_swap to 0.
				global.can_swap = 0;
		
				// Wait 15 steps for the current move to animate before
				// checking for matches. If you change the speed at which
				// the pieces move in the step event, you will also need
				// to change this value.
				var _ts_check_for_matches = time_source_create(time_source_game, 15, time_source_units_frames, check_for_matches);
				time_source_start(_ts_check_for_matches);
		
				// Apply the following code to the _piece_to_swap
				with(_piece_to_swap) 
				{
					// Wait 15 steps for the current move to animate before
					// checking for matches. If you change the speed at which
					// the pieces move in the step event, you will also need
					// to change this value.
					_ts_check_for_matches = time_source_create(time_source_game, 15, time_source_units_frames, check_for_matches);
					time_source_start(_ts_check_for_matches);
				}
		
				// Since we have already started processing a valid move, exit the
				// current event so that no more drags are processed.
				exit;
			}
		}

		// The player dragged this matching piece one square to the left
		if(_drag_horizontal < -sprite_width / 2)
		{
			// Check if there is a piece on the playfield
			// one square to the left of the piece currently
			// being dragged.
			// If yes, assign the id of the piece we want to
			// swap with to a temporary variable called
			// _piece_to_swap.
			var _piece_to_swap = collision_point(x - sprite_width, y, obj_matching_piece, true, 1);
			if((_piece_to_swap))
			{
				// Play a sound effect indicating that the
				// pieces are being swapped.
				audio_play_sound(snd_piece_swap, 0, 0);
		
				// Set the current piece to move to the left
				// by updating the target_x variable which
				// the piece will approach in the step event
				target_x -= sprite_width;
		
				// Tell the piece we're swapping with to move
				// to the right by updating the target_x variable which
				// the piece will approach in its step event
				_piece_to_swap.target_x += _piece_to_swap.sprite_width;
		
				// Tell the piece we're swapping with which piece
				// forced it to swap by changing its swap_parent
				// variable to the id of this instance
				_piece_to_swap.swap_parent = id;
		
				// For this piece, set the variable swap_parent to the id
				// of the _piece_to_swap so that we can use it later
				swap_parent = _piece_to_swap;
		
				// The player performed a valid move and the game will
				// now need to calculate the result of that move before
				// we let the player move again.
				// Here we set the global variable can_swap to 0.
				global.can_swap = 0;
		
				// Wait 15 steps for the current move to animate before
				// checking for matches. If you change the speed at which
				// the pieces move in the step event, you will also need
				// to change this value.
				var _ts_check_for_matches = time_source_create(time_source_game, 15, time_source_units_frames, check_for_matches);
				time_source_start(_ts_check_for_matches);
		
				// Apply the following code to the _piece_to_swap
				with(_piece_to_swap) 
				{
					// Wait 15 steps for the current move to animate before
					// checking for matches. If you change the speed at which
					// the pieces move in the step event, you will also need
					// to change this value.
					_ts_check_for_matches = time_source_create(time_source_game, 15, time_source_units_frames, check_for_matches);
					time_source_start(_ts_check_for_matches);
				}
		
				// Since we have already started processing a valid move, exit the
				// current event so that no more drags are processed.
				exit;
			}
		}

		// The player dragged this matching piece one square downwards
		if(_drag_vertical > sprite_height / 2)
		{
			// Check if there is a piece on the playfield
			// one square below the piece currently
			// being dragged.
			// If yes, assign the id of the piece we want to
			// swap with to a temporary variable called
			// _piece_to_swap.
			var _piece_to_swap = collision_point(x, y + sprite_height, obj_matching_piece, true, 1);
			if((_piece_to_swap))
			{
				// Play a sound effect indicating that the
				// pieces are being swapped.
				audio_play_sound(snd_piece_swap, 0, 0);
		
				// Set the current piece to move downwards
				// by updating the target_y variable which
				// the piece will approach in the step event
				target_y += sprite_height;
		
				// Tell the piece we're swapping with to move
				// upwards by updating the target_y variable which
				// the piece will approach in its step event
				_piece_to_swap.target_y -= _piece_to_swap.sprite_height;
		
				// Tell the piece we're swapping with which piece
				// forced it to swap by changing its swap_parent
				// variable to the id of this instance
				_piece_to_swap.swap_parent = id;
		
				// For this piece, set the variable swap_parent to the id
				// of the _piece_to_swap so that we can use it later
				swap_parent = _piece_to_swap;
		
				// The player performed a valid move and the game will
				// now need to calculate the result of that move before
				// we let the player move again.
				// Here we set the global variable can_swap to 0.
				global.can_swap = 0;
		
				// Wait 15 steps for the current move to animate before
				// checking for matches. If you change the speed at which
				// the pieces move in the step event, you will also need
				// to change this value.
				var _ts_check_for_matches = time_source_create(time_source_game, 15, time_source_units_frames, check_for_matches);
				time_source_start(_ts_check_for_matches);
		
				// Apply the following code to the _piece_to_swap
				with(_piece_to_swap) 
				{
					// Wait 15 steps for the current move to animate before
					// checking for matches. If you change the speed at which
					// the pieces move in the step event, you will also need
					// to change this value.
					_ts_check_for_matches = time_source_create(time_source_game, 15, time_source_units_frames, check_for_matches);
					time_source_start(_ts_check_for_matches);
				}
		
				// Since we have already started processing a valid move, exit the
				// current event so that no more drags are processed.
				exit;
			}
		}

		// The player dragged this matching piece one square upwards
		if(_drag_vertical < -sprite_height / 2)
		{
			// Check if there is a piece on the playfield
			// one square above the piece currently
			// being dragged.
			// If yes, assign the id of the piece we want to
			// swap with to a temporary variable called
			// _piece_to_swap.
			var _piece_to_swap = collision_point(x, y - sprite_height, obj_matching_piece, true, 1);
			if((_piece_to_swap))
			{
				// Play a sound effect indicating that the
				// pieces are being swapped.
				audio_play_sound(snd_piece_swap, 0, 0);
		
				// Set the current piece to move upwards
				// by updating the target_y variable which
				// the piece will approach in the step event
				target_y -= sprite_height;
		
				// Tell the piece we're swapping with to move
				// downwards by updating the target_y variable which
				// the piece will approach in its step event
				_piece_to_swap.target_y += _piece_to_swap.sprite_height;
		
				// Tell the piece we're swapping with which piece
				// forced it to swap by changing its swap_parent
				// variable to the id of this instance
				_piece_to_swap.swap_parent = id;
		
				// For this piece, set the variable swap_parent to the id
				// of the _piece_to_swap so that we can use it later
				swap_parent = _piece_to_swap;
		
				// The player performed a valid move and the game will
				// now need to calculate the result of that move before
				// we let the player move again.
				// Here we set the global variable can_swap to 0.
				global.can_swap = 0;
		
				// Wait 15 steps for the current move to animate before
				// checking for matches. If you change the speed at which
				// the pieces move in the step event, you will also need
				// to change this value.
				var _ts_check_for_matches = time_source_create(time_source_game, 15, time_source_units_frames, check_for_matches);
				time_source_start(_ts_check_for_matches);
		
				// Apply the following code to the _piece_to_swap
				with(_piece_to_swap) 
				{
					// Wait 15 steps for the current move to animate before
					// checking for matches. If you change the speed at which
					// the pieces move in the step event, you will also need
					// to change this value.
					_ts_check_for_matches = time_source_create(time_source_game, 15, time_source_units_frames, check_for_matches);
					time_source_start(_ts_check_for_matches);
				}
		
				// Since we have already started processing a valid move, exit the
				// current event so that no more drags are processed.
				exit;
			}
		}
	}
}