//import { onClick } from "./reCAPTCHAV3.js";

$(document).ready(() => {
	getCreditCount();
	$('#submitPromptButton').on('click', () => {
		const userPrompt = document.getElementById("userPrompt")
		const recaptcha = $("#dalleRecaptcha").val();
		if (userPrompt.value != "") {
			console.log(userPrompt);
			console.log(recaptcha);
			$.ajax({
				method: "GET",
				url: `/api/Dalle/GetImages?prompt=${userPrompt.value}&gRecaptchaResponse=${recaptcha}`,
				dataType: "json",					// data type expected in response
				success: displayImage,
				error: displayErrorStatusToClient
			});
		};
	});
	$('#applyProfilePhoto').on('click', () => {
		applyProfilePhoto();
	});
});

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
	//$('#creditsCounter').empty()
	//	.text(`Credits remaining: ${data}`);
}

function dalleModalOpen() {
	$('#DalleModal').modal('show');
}
function dalleModalClose() {
	$('#DalleModal').modal('hide');
}

function displayImage(data) {
	getCreditCount(); //update the number of credits a user has on the view.
	displayStatusToClient();
	console.log("Successfully made image with dalle: " + data);

	let temp = document.createElement("img");
	$("img").attr("id", "dalleImage");
	temp.src = `${data.responseText}`;
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

function displayErrorStatusToClient() {
	$("#statusNotificationDiv").empty();
	const notification = `<div class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            <h1>Something went wrong...</h1>
                          </div>`;
	$("#statusNotificationDiv").append(notification);
}

function errorOnAjax(data) {
	console.log("Error in AJAX call" + data.url);
}

$(function () {
	$("#promptForm").submit(function (event) {
		// prevent automatic submission of the form from button press or typing enter
		event.preventDefault();
	});
});

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
		url: "/api/Dalle/UpdateProfilePicture",
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