//import { onClick } from "./reCAPTCHAV3.js";

$(document).ready(() => {
	getCreditCount();
	$('#submitPromptButton').on('click', (event) => {
		event.preventDefault();
		const userPrompt = document.getElementById("userPrompt")
		const recaptcha = $("#dalleRecaptcha").val();
		if (userPrompt.value != "") {
			console.log(userPrompt.value);
			// console.log(recaptcha);
			// $.ajax({
			// 	method: "GET",
			// 	url: `/api/Dalle/GetImages?prompt=${userPrompt.value}&gRecaptchaResponse=${recaptcha}`,
			// 	dataType: "text",					// data type expected in response
			// 	success: displayImage,
			// 	error: displayErrorStatusToClient
			// });
			getImage(userPrompt.value, recaptcha);
		};
	});
	$('#applyProfilePhoto').on('click', () => {
		applyProfilePhoto();
	});
});

// q: why is the success callback not getting called when the server is returning a 200 OK and a json object?
// a: the server is returning a 200 OK and a json object, but the json object is an error message, not the image.
// q: how can I fix this?
// a: the server is returning a 200 OK and a json object, but the json object is an error message, not the image
//https://oaidalleapiprodscus.blob.core.windows.net/private/org-vorTZHzP88yLvlZRpgybCNtA/user-CPGiIMFKqsp4L3aULI4nH48Z/img-kbmeFeZbLLirsZEPQYAo8IO8.png?st=2023-04-25T04%3A28%3A29Z&se=2023-04-25T06%3A28%3A29Z&sp=r&sv=2021-08-06&sr=b&rscd=inline&rsct=image/png&skoid=6aaadede-4fb3-4698-a8f6-684d7786b067&sktid=a48cca56-e6da-484e-a814-9c849652bcb3&skt=2023-04-25T05%3A10%3A23Z&ske=2023-04-26T05%3A10%3A23Z&sks=b&skv=2021-08-06&sig=FUrGQU6iQRRFkpCBsUxwHO%2BHQxj9s7MKTOmeVBh3l6I%3D
function getImage(promt, recaptcha) {
	$.ajax({
		method: "GET",
		url: `/api/Dalle/GetImages?prompt=${promt}&gRecaptchaResponse=${recaptcha}`,
		dataType: "text",					// data type expected in response
		success: function (data) {
			displayImage(data);
		},
		error: displayErrorStatusToClient
	});
}

function getCreditCount() {
	const baseUrl = $(location).attr("origin");
	$.ajax({
		method: "GET",
		url: `${baseUrl}/api/Dalle/GetCreditsForView`,
		contentType: "json",
		success: successGettingCreditCount,
		errorOnAjax: errorGettingCreditCount
	});
}
function successGettingCreditCount(data) {
	console.log('succeeded getting credit count');
	if (data === 0) {
		$('#creditsCounter').empty()
			.text(`Credits remaining: ${data} You have used all of your free credits.`);
		$('#userPrompt').prop('disabled', true);
		$('#submitPromptButton').prop('disabled', true);
		return;
	}
	$('#creditsCounter').empty()
		.text(`Credits remaining: ${data}`);

}
function errorGettingCreditCount(data) {
	console.log('failed getting credit count');
}

// function dalleModalOpen() {
// 	$('#DalleModal').modal('show');
// }
// function dalleModalClose() {
// 	$('#DalleModal').modal('hide');
// }

function displayImage(data) {
		getCreditCount(); //update the number of credits a user has on the view.
		displayStatusToClient();
		console.log("Successfully made image with dalle: " + data);
		console.log(typeof(data));
		let temp = document.createElement("img");
		$("img").attr("id", "dalleImage");
		temp.src = `${data}`;
		temp.style.display = "block";
		temp.style.marginLeft = "auto";
		temp.style.marginRight = "auto";
		document.getElementById("applyProfilePhoto").removeAttribute("hidden");
		document.getElementById("imageHere").removeAttribute("hidden");

		document.getElementById("imageHere").innerHTML = "";
		//document.getElementById("imageHere").setAttribute("href", `${data.responseText}`)
		//document.getElementById("imageHere").setAttribute("download", "DalleGeneratedImage")
		document.getElementById("imageHere").appendChild(temp);
		document.getElementById("submitPromptButton").setAttribute("aria-disabled", "false");


		//document.getElementById("imageHere").removeAttribute("hidden");
		//document.getElementById("imageHere").setAttribute("src", `${data.responseText}`)
}

function displayStatusToClient() {
	$("#statusNotificationDiv").empty();
	const notification = `<div class="alert alert-success alert-dismissible" role="alert">
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            <h1>Successfully made image with DALL-E!</h1>
                          </div>`;
	$("#statusNotificationDiv").append(notification);
}

function displayErrorStatusToClient(data) {
	console.log(data);
	console.log(typeof(data.responseText));
	$("#statusNotificationDiv").empty();
	const notification = `<div class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            <h1>Something went wrong...</h1>
                          </div>`;
	$("#statusNotificationDiv").append(notification);
}

function successUpdatingProfilePicture(data) {
	alert("success updating profile picture");
}

function errorUpdatingProfilePicture(data) {
	alert("error updating profile picture");
}

function applyProfilePhoto() {
	const imageUrl = $('#dalleImage').attr('src');
	console.log("image url: " + imageUrl);
	$.ajax({
		method: "POST",
		url: "/api/Dalle/SetImageToProfilePicure",
		data: { imageUrl: imageUrl },
		success: successUpdatingProfilePicture,
		error: errorUpdatingProfilePicture
	});
}

// function dalleClick() {
// 	const userPrompt = document.getElementById("userPrompt")
// 	const recaptcha = $("#dalleRecaptcha").val();
// 	if (userPrompt.value != "") {
// 		console.log(userPrompt);
// 		console.log(recaptcha);
// 		$.ajax({
// 			method: "GET",
// 			url: `/api/Dalle/GetImages?prompt=${userPrompt.value}&gRecaptchaResponse=${recaptcha}`,
// 			dataType: "json",					// data type expected in response
// 			success: displayImage,
// 			error: displayErrorStatusToClient
// 		});
// 	};
// };