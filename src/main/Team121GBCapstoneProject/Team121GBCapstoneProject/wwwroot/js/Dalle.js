
function displayImage(data) {
	console.log("Successfully made image with dalle: " + data);

	let temp = document.createElement("img");
	temp.src = `${data.responseText}`;
	document.getElementById("imageHere").appendChild(temp);
}

function errorOnAjax(data) {
	console.log("Error in AJAX call" + data.url);
}

$(function () {
	$("#promptForm").submit(function (event) {
		// prevent automatic submission of the form from button press or typing enter
		event.preventDefault();
	})

	$("#submitPromptButton").click(function () {
		const userPrompt = document.getElementById("userPrompt")
		console.log(userPrompt);
			$.ajax({
				method: "GET",
				url: `/api/Dalle/GetImages?prompt=${userPrompt.value}`,
				dataType: "json",					// data type expected in response
				success: displayImage,
				error: displayImage
			});
	});
});