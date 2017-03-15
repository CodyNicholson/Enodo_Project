
    var width = 700,
        height = 800;
    var diameter = 400;
    var duration = 2000;
    var jsonData;
    var currentColor = "#e41a1c";
    var pattern = "\/([0-9]+)(?=[^\/]*$)";
    var url = top.document.location.href.toString();
    var index = url.match(pattern)[1];
//  var index = url.substring(url.lastIndexOf("/") + 1, url.lastIndexOf("?"));
    
    //var index = url.substr(-1);
   //console.log("JNDJFDJF:  " + index);


    d3.json("/Scripts/_output"+index+".json", function (jdata) {
        //console.log(jdata);

        d3.selectAll("input").on("change", change);





        function change() {
            if (this.value === "radialtree")
                transitionToRadialTree();
            else if (this.value === "radialcluster")
                transitionToRadialCluster();
            else if (this.value === "tree")
                transitionToTree();
            else
                transitionToCluster();
        };

        function transitionToRadialTree() {

            var nodes = radialTree.nodes(root), // recalculate layout
                links = radialTree.links(nodes);

            svg.transition().duration(duration)
                .attr("transform", "translate(" + (width / 2) + "," +
                                                  (height / 2) + ")");
            // set appropriate translation (origin in middle of svg)

            link.data(links)
                .transition()
                .duration(duration)
                .style("stroke", "#fc8d62")
                .attr("d", radialDiagonal); //get the new radial path

            node.data(nodes)
                .transition()
                .duration(duration)
                .attr("transform", function (d) {
                    return "rotate(" + (d.x - 90) + ")translate(" + d.y + ")";
                });

            node.select("circle")
                .transition()
                .duration(duration)
                .style("stroke", "#984ea3");

            /*node.select("text")
            .transition()
            .duration(duration)
              .attr("transform", function(d){
    
                return d.children ?"rotate(" + (d.x > 180 ? d.x - 180 : d.x + 180) + ")" : null;
              })
            ;*/

        };

        function transitionToRadialCluster() {

            var nodes = radialCluster.nodes(root), // recalculate layout
                links = radialCluster.links(nodes);

            svg.transition().duration(duration)
                .attr("transform", "translate(" + (width / 2) + "," +
                                                  (height / 2) + ")");
            // set appropriate translation (origin in middle of svg)

            link.data(links)
                .transition()
                .duration(duration)
                .style("stroke", "#66c2a5")
                .attr("d", radialDiagonal); //get the new radial path

            node.data(nodes)
                .transition()
                .duration(duration)
                .attr("transform", function (d) {
                    return "rotate(" + (d.x - 90) + ")translate(" + d.y + ")";
                });

            node.select("circle")
                .transition()
                .duration(duration)
                .style("stroke", "#4daf4a");

        };

        function transitionToTree() {

            var nodes = tree.nodes(root), //recalculate layout
                links = tree.links(nodes);

            svg.transition().duration(duration)
                .attr("transform", "translate(100,0)");

            link.data(links)
                .transition()
                .duration(duration)
                .style("stroke", "#e78ac3")
                .attr("d", diagonal); // get the new tree path

            node.data(nodes)
                .transition()
                .duration(duration)
                .attr("transform", function (d) {
                    return "translate(" + d.y + "," + d.x + ")";
                });

            node.select("circle")
                .transition()
                .duration(duration)
                .style("stroke", "#377eb8");

        };

        function transitionToCluster() {

            var nodes = cluster.nodes(root), //recalculate layout
                links = cluster.links(nodes);

            svg.transition().duration(duration)
                .attr("transform", "translate(100,0)");

            link.data(links)
                .transition()
                .duration(duration)
                .style("stroke", "#8da0cb")
                .attr("d", diagonal); //get the new cluster path

            node.data(nodes)
                .transition()
                .duration(duration)
                .attr("transform", function (d) {
                    return "translate(" + d.y + "," + d.x + ")";
                });

            node.select("circle")
                .transition()
                .duration(duration)
                .style("stroke", "#e41a1c");



        };

        var root; // store data in a variable accessible by all functions

        var tree = d3.layout.tree()
            .size([height, width - 250]);

        var cluster = d3.layout.cluster()
            .size([height, width - 250]);

        var diagonal = d3.svg.diagonal()
            .projection(function (d) {
                return [d.y, d.x];
            });

        var radialTree = d3.layout.tree()
            .size([360, diameter / 2])
            .separation(function (a, b) {
                return (a.parent === b.parent ? 1 : 2) / a.depth;
            });

        var radialCluster = d3.layout.cluster()
            .size([360, diameter / 2])
            .separation(function (a, b) {
                return (a.parent === b.parent ? 1 : 2) / a.depth;
            });

        var radialDiagonal = d3.svg.diagonal.radial()
            .projection(function (d) {
                return [d.y, d.x / 180 * Math.PI];
            });


        var svg = d3.select("body").append("svg")
            .attr("width", width + 100)
            .attr("height", height + 100)
            .append("g")
            .attr("transform", "translate(100,5)");



        //d3.json("data.json", function(jdata) {
        root = jdata[0],
            nodes = cluster.nodes(root),
            links = cluster.links(nodes);


        var link = svg.selectAll(".link")
            .data(links)
           .enter()
            .append("path")
            .attr("class", "link")
            .style("stroke", "#8da0cb")
            .attr("d", diagonal);

        var node = svg.selectAll(".node")
            .data(nodes)
           .enter()
            .append("g")
            .attr("class", "node")
            .attr("transform", function (d) {
                return "translate(" + d.y + "," + d.x + ")";
            })

        node.append("circle")
            .attr("r", function (d) { return !d.children ? 6 : 8 })
            .on("click", click)
            .style("stroke", "#e41a1c");

        /*  node.append("text")
              .attr("dy", ".31em")
              .attr("x", function(d) { return d.x < 180 === !d.children ? 6 : -6; })
              .style("text-anchor", function(d) { return d.x < 180 === !d.children ? "start" : "end"; })
              .attr("transform", function(d) { return "rotate(" + (d.x < 180 ? d.x - 90 : d.x + 90) + ")"; })
              .text(function(d) { return d.name });*/

        node.append("text")
            .text(function (d) {
                return d.name;
            })
            .attr("x", function (d) { return !d.children ? 25 : 15 })
            .attr("y", function (d) { return !d.children ? 5 : -15 })
            .attr("text-anchor", function (d) { return d.children || d._children ? "end" : "start"; })
            //.attr("transform", function(d) { return d.children ?"rotate(" + (d.x < 180 ? d.x - 180 : d.x + 180) + ")" : null; })
            .text(function (d) {
                return d.name.toUpperCase();
            })
            .style("fill-opacity", 1)
            .style("stroke", function (d) { return !d.children ? "grey" : "#5FBAAC" })
            .style("stroke-width", function (d) { return !d.children ? "0.5px" : "1px" })

        ;

        function click(d) {
            var options = d.parent.parent.options;

            if (!d.children) {

                
                var name = d.name,
                    gender = d.Gender,
                    num = d.num,
                    dm = d.Demographic,
                    ans = d.numanswers,
                    parent = d.parent.name;

                //var top_ans = ans.split(",");

                document.getElementById("name").innerHTML = name;
                document.getElementById("gender").innerHTML = gender;
                document.getElementById("num").innerHTML = num;
                document.getElementById("dm").innerHTML = dm;
                document.getElementById("top_ans").innerHTML = options[ans[0]];
                document.getElementById("b_ans").innerHTML = options[ans[ans.length - 1]];
          

                $(function () {
                    $("#dialog").dialog({title: parent, modal: true});
                });

               // $('#dialog').dialog('option', 'title', parent);
            }
          


        }

        /*  node.append("text")
              .attr("x", function(d){ return 25;
              })
              .attr("y", function(d){ return 0;
              })
              .text(function(d) {return "hgeelo";})*/
    });

    function getData() {
        console.log(jsonData);
        return jsonData
    }


