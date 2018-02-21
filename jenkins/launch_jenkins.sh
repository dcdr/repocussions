docker run \
  -u root \
  --rm \
  -d \
  -p 8080:8080 \
  -p 50000:50000 \
  -v ~/.jenkins_home:/var/jenkins_home \
  -v /var/run/docker.sock:/var/run/docker.sock \
  --name jenkins_blueocean \
  jenkinsci/blueocean

echo "Give Jenkins a few seconds to boot up."
echo "If this is the first launch, then execute 'docker logs jenkins_blueocean' to retrieve the initial password."
echo "Hit refresh on the browser until Jenkins is active."

open http://localhost:8080
