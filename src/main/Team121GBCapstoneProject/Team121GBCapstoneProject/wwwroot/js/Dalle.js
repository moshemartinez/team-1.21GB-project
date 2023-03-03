
function afterAddPerson(data) {
	console.log("Successfully added person: " + data.status);
}

function errorOnAjax(data) {
	console.log("Error in AJAX call: " + data.status);
}

$(function () {
	$("#promptForm").submit(function (event) {
		// prevent automatic submission of the form from button press or typing enter
		event.preventDefault();
	});
	// Add callback to the add person button
	$("#submitPromptButton").click(function () {
		const prompt = document.getElementById("userPrompt")
		console.log(values);
			$.ajax({
				method: "POST",
				url: "/api/GetImages",
				dataType: "json",					// data type expected in response
				contentType: "application/json; charset=UTF-8",	// data type to send
				data: JSON.stringify(values),
				success: afterAddPerson,
				error: errorOnAjax
			});
	});
});