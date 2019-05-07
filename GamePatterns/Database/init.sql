create table settings
(
    id int primary key,
    [name] varchar(20) not null,
    [value] varchar(20)
);

create table spritemap
(
    id int primary key,
    [name] varchar(20)
);

insert into spritemap (id, [name])
values
(0, 'player'),
(1, 'world');

create table spritemap_sprite
(
    id int primary key,
    [name] varchar(200) not null,
    x int not null,
    y int not null,
    width int not null,
    height int not null,
    spritemap_id int not null,
    foreign key(spritemap_id) references spritemap(id)
);

insert into spritemap_sprite (id, [name], x, y, width, height, spritemap_id)
values
(0, 'player_walk_south', 0, 0, 32, 32, 0),

(1, 'world_grass', 0, 0, 32, 32, 1),
(2, 'world_brick', 32, 0, 32, 32, 1);

create table animation
(
    id int primary key,
    [name] varchar(20),
    spritemap_id int not null,
    foreign key(spritemap_id) references spritemap(id)
);

create table animation_frame
(
    id int primary key,
	[sequence] int not null,
    [length] int not null default 1,
    animation_id int not null,
    sprite_id int not null,
    foreign key(animation_id) references animation(id),
    foreign key(sprite_id) references spritemap_sprite(id)
);

create table world
(
    id int primary key,
	[name] varchar(50)
);

create table world_tile
(
    id int primary key,
    collisiontype int not null default 0,
    world_id int not null,
    sprite_id int not null,
    foreign key(world_id) references world(id),
    foreign key(sprite_id) references spritemap_sprite(id)
);

create table dialogue
(
	id int primary key,
	parent_id int,
	[text] varchar(300) not null,
	[sequence] int not null default 0,
	requiredresponse_id int,
	tree_id int not null,
	foreign key(requiredresponse_id) references dialogue_response(id)
);

create table dialogue_response
(
	id int primary key,
	dialogue_id int not null,
	[text] varchar(300) not null,
	[sequence] int not null default 0,
	tree_id int not null,
	foreign key(dialogue_id) references dialogue(id)
);