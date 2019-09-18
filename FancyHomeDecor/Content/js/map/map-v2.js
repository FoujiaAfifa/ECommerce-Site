// Google maps
    $('.maps-vs').each(function() {
        var $this = $(this),
            $id = $this.attr('id'),
            $zoom = parseInt($this.attr('data-zoom')),
            $latitude = $this.attr('data-latitude'),
            $longitude = $this.attr('data-longitude'),
            $address = $this.attr('data-address'),
            $info_title = $this.attr('data-info_title'),
            $phone = $this.attr('data-phone'),
            $email = $this.attr('data-email'),
            $website = $this.attr('data-website'),
            $map_type = $this.attr('data-map-type'),
            $pin_icon = $this.attr('data-pin-icon'),
            $pan_control = $this.attr('data-pan-control') === "true" ? true : false,
            $map_type_control = $this.attr('data-map-type-control') === "true" ? true : false,
            $scale_control = $this.attr('data-scale-control') === "true" ? true : false,
            $draggable = $this.attr('data-draggable') === "true" ? true : false,
            $zoom_control = $this.attr('data-zoom-control') === "true" ? true : false,
            $modify_coloring = $this.attr('data-modify-coloring') === "true" ? true : false,
            $saturation = $this.attr('data-saturation'),
            $hue = $this.attr('data-hue'),
            $lightness = $this.attr('data-lightness'),
            $styles;


        if ($modify_coloring == true) {
          var $styles = [{
            stylers:
            [
              {
                hue: $hue
              },
              {
                saturation: $saturation
              },
              {
                lightness: $lightness
              },
              {
                featureType: "landscape.man_made",
                stylers: [{
                  visibility: "on"
                }]
              }
            ]
          }];
        }

        var map;

        function initialize()
        {
          var bounds = new google.maps.LatLngBounds();
          var mapOptions = {
            zoom: $zoom,
            panControl: $pan_control,
            zoomControl: $zoom_control,
            mapTypeControl: $map_type_control,
            scaleControl: $scale_control,
            draggable: $draggable,
            scrollwheel: false,
            mapTypeId: google.maps.MapTypeId[$map_type],
            styles: $styles
          };

          map = new google.maps.Map(document.getElementById($id), mapOptions);
          map.setTilt(45);

          // Multiple Markers

          var markers = [];
          var infoWindowContent = [];

          if ($latitude != '' && $longitude != '') {
            markers[0] = [$address, $latitude, $longitude];

            var info_show_html = '';
            if ( $.trim( $info_title ) != '' ) {
                info_show_html += '<h4 class="map_info_title">' + $info_title + '</h4>';
            }

            if ( $.trim( $address ) != '' ) {
                info_show_html += '<p>' + $address + '</p>';
            }

            if ( $.trim( $phone ) != '' ) {
                info_show_html += '<i class="fa fa-phone"></i>' + $phone + '<br />';
            }

            if ( $.trim( $email ) != '' ) {
                info_show_html += '<i class="fa fa-envelope"></i><a href="mailto:' + $email + '">' + $email + '</a><br />';
            }

            if ( $.trim( $website ) != '' ) {
                info_show_html += '<i class="fa fa-globe"></i><a href="' + $website + '" target="_blank">' + $website + '</a><br />';
            }

            if ( $.trim( info_show_html ) != '' ) {
                info_show_html = '<div class="map_info_box">' + info_show_html + '</div>';
            }

            infoWindowContent[0] = [info_show_html];
          }

          var infoWindow = new google.maps.InfoWindow(), marker, i;

          for (i = 0; i < markers.length; i++)
          {
            var position = new google.maps.LatLng(markers[i][1], markers[i][2]);
            bounds.extend(position);
            marker = new google.maps.Marker({
              position: position,
              map: map,
              title: markers[i][0],
              icon: $pin_icon
            });

            google.maps.event.addListener(marker, 'click', (function(marker, i) {
              return function() {
                if(infoWindowContent[i][0].length > 1) {
                    console.log(infoWindowContent[i][0]);
                    infoWindow.setContent(infoWindowContent[i][0]);
                }

                infoWindow.open(map, marker);
              }
            })(marker, i));

            map.fitBounds(bounds);

          }

          var boundsListener = google.maps.event.addListener((map), 'bounds_changed', function(event) {
            this.setZoom($zoom);
            google.maps.event.removeListener(boundsListener);
          });
        }

        initialize();

        function googleMapsResize() {
          initialize();
        }

        var temporaryTabsContainer = jQuery('.mk-tabs');
        if (temporaryTabsContainer.length) {
          temporaryTabsContainer.each(function() {
            google.maps.event.addDomListener($(this)[0], "click", googleMapsResize);
          });

        }

        var fullHeight = $this.hasClass('full-height-map');
        function fullHeightMap()
        {
            if (fullHeight)
            {
                var $window_height = jQuery(window).outerHeight(), wp_admin_height = 0, header_height = 0;
                if(jQuery.exists('#mk-header .mk-header-holder')) {
                    header_height = parseInt(jQuery('#mk-header').attr('data-sticky-height'));
                }

                if (jQuery.exists("#wpadminbar")) {
                    var wp_admin_height = jQuery("#wpadminbar").outerHeight();
                }

                $window_height = $window_height - wp_admin_height - header_height;
                $this.css('height', $window_height);
            }
        }

        fullHeightMap();
        jQuery(window).on('debouncedresize', fullHeightMap);
    });
