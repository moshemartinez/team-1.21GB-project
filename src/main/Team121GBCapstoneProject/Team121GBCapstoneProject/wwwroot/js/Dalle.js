
function displayImage(data) {
	console.log("Successfully made image with dalle: " + data);

	
}

function errorOnAjax(data) {
	console.log("Error in AJAX call" + data);
}

$(function () {
	$("#promptForm").submit(function (event) {
		// prevent automatic submission of the form from button press or typing enter
		event.preventDefault();
	})

	$("#submitPromptButton").click(function () {
		const userPrompt = document.getElementById("userPrompt")
		console.log(values);
			$.ajax({
				method: "GET",
				url: "/api/Dalle/GetImages?prompt=${userPrompt}",
				dataType: "json",					// data type expected in response
				contentType: "application/json; charset=UTF-8",	// data type to send
				success: afterAddPerson,
				error: errorOnAjax
			});
	});
});