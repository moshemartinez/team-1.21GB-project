
// Use this function for updating the SearchResults page using Ajax

function displaySearchResults(query, platform, genre, esrbRating) {

    $.ajax({
        type: "GET",
        url: "/api/Game",
        data: { query: query,
                platform: platform ,
                genre: genre,
                esrbRating: esrbRating
            }, 
        dataType: "json",
        success: function (data) {
            if (data.length === 0) {
                // Display "No results found" message
                $("#gameTableBody").html("<tr> <td colspan=\"4\" style=\"text-align: center; color: gray;\">No results found</td></tr>");
            } else {
                $("#gameTableBody").empty(); // clear the table body before populating with new data
                $.each(data,
                    function (i, game) {
                        try {
                            // resize cover image
                            var resizedCoverArt = game.gameCoverArt.replace("thumb", "logo_med");

                            var row = `<tr>
                                    <td><img src="${resizedCoverArt}"></td>
                                    <td><b>${game.gameTitle}</b></td>
                                    <td><a class="btn btn-primary" href="${game.gameWebsite}">IGDB Page</a></td>
                                    <td><p>${game.gameDescription}</p></td>
                                    <td><p>${game.firstReleaseDate}</p></td>
                                    <td><button id="${i}" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#AddGame">Add Game</button></td>
                                    <td style="display: none">${game.id}</td>
                               </tr>`;
                            $("#gameTableBody").append(row);
                        }
                        catch {
                            // resize cover image
                            let noCover = "https://images.igdb.com/igdb/image/upload/t_thumb/nocover.png";
                            var resizedCoverArt = noCover.replace("thumb", "logo_med");
                            var row = `<tr>
                                    <td><img src="${resizedCoverArt}"></td>
                                    <td><b>${game.gameTitle}</b></td>
                                    <td><a class="btn btn-primary" href="${game.gameWebsite}">IGDB Page</a></td>
                                    <td><p>${game.gameDescription}</p></td>
                                    <td><p>${game.firstReleaseDate}</p></td>
                                    <td><button id="${i}" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#AddGame">Add Game</button></td>
                                    <td style="display: none">${game.id}</td>
                               </tr>`;
                            $("#gameTableBody").append(row);
                        }
                    });
            }
        }
    });
}
//$(document).on('mouseenter', 'tbody tr', function() {
//    $(this).animate({
//      height: '+=50px'
//    }, 'fast');
//  });
  
//  $(document).on('mouseleave', 'tbody tr', function() {
//    $(this).animate({
//      height: '-=50px'
//    }, 'fast');
//  });

// $(document).on('mouseenter', 'tr', function() {
//     $(this).find('td').animate({
//       height: '+=50px',
//       width: '+=50px'
//     }, 'slow');
//   });
  
//   $(document).on('mouseleave', 'tr', function() {
//     $(this).find('td').animate({
//       height: '-=50px',
//       width: '-=50px'
//     }, 'slow');
//   });


// $(() => {
//     $('tr').on('mouseenter', (event) => {
//         $(event.currentTarget).animate({
//           width: '800px',
//           height: '800px'
//         }, 'fast');
//       }).on('mouseleave', (event) => {
//         $(event.currentTarget).animate({
//             width: '',
//             height: ''
//           }, 'fast');
//       });
// });