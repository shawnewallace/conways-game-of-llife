﻿var board = "";
var reloading;
var tickCount = 0;

$(document).ready(function () {
	$("#service-tick").click(function () {
		tick();
	});

	$("#reset-game-board").click(function () {
		reset();
	});

	$("#new-board").click(function () {
		newBoard();
	});

	$("#toggle-auto-refresh").change(function () {
		toggleRefresh($(this));
	});

	$(document).on("click", ".cell", function () {
		var x = $(this).data("x");
		var y = $(this).data("y");

		if ($(this).hasClass("alive")) {
			$(this).removeClass("alive");
			$(this).addClass("dead");
			board.board[x][y] = false;
		} else {
			$(this).removeClass("dead");
			$(this).addClass("alive");
			board.board[x][y] = true;
		}
	});
});

var toggleRefresh = function (checkbox) {
	var checked = checkbox.is(":checked");

	if (checked) {
		reloading = setInterval("tick();", 1000);
	} else {
		clearInterval(reloading);
	}
}

var reset = function () {
	$("#game-board").html("");
	$("#width").val(10);
	$("#height").val(10);
	$("#fill-factor").val(.5);
	$("#tickCount").text("");
	tickCount = 0;
};

var newBoard = function () {
	var URL = "/api/Game";

	var width = $("#width").val();
	var height = $("#height").val();
	var fillFactor = $("#fill-factor").val();
	var initialState = $("#initial-state").val();

	var data = {
		"width": width,
		"height": height,
		"fillfactor": fillFactor,
		"generator": initialState
	};

	$.ajax({
		url: URL,
		type: "POST",
		data: JSON.stringify(data),
		contentType: "application/json",
		success: function (result) {
			tickCount = 0;
			board = result;
			drawBoard();
		}
	});
};

var tick = function () {
	var URL = "/api/Game";

	$.ajax({
		url: URL,
		type: "PUT",
		data: JSON.stringify(board),
		contentType: "application/json",
		success: function (result) {
			tickCount = tickCount + 1;
			board = result;
			drawBoard();
		}
	});
};

var drawBoard = function () {
	var height = board.height;
	var width = board.width;

	var cellSize = "cell-big";
	if (height > 20 || width > 20) cellSize = "cell-normal";
	if (height > 70 || width > 70) cellSize = "cell-small";

	var boardTable = "<table>";

	for (var y = 0; y < height; y++) {
		boardTable = boardTable + "<tr>";
		for (var x = 0; x < width; x++) {
			if (board.board[x][y] == true) {
				boardTable = boardTable + "<td class='cell " + cellSize + " alive' data-x='" + x + "' data-y='" + y + "'><div></div>";
			} else {
				boardTable = boardTable + "<td class='cell " + cellSize + " dead' data-x='" + x + "' data-y='" + y + "'><div></div>";
			}
			boardTable = boardTable + "</td>";
		}
		boardTable = boardTable + "</tr>";
	}

	boardTable = boardTable + "</table>";

	$("#tickCount").text(tickCount);

	//$("#game-board").fadeOut(100, function() {
	//	$("#game-board").html(boardTable).fadeIn(100);
	//});


	//$("#game-board").fadeOut().html(boardTable).fadeIn();
	$("#game-board").html(boardTable);
	//$("#game-board").fadeIn();
};