pipeline {
    agent none
    stages {
        stage('build') {
            agent { docker 'microsoft/aspnetcore-build:2.0' }
            steps {
               sh 'dotnet build' 
            }
        }
        stage('unit test') {
            agent { docker 'microsoft/aspnetcore-build:2.0' }
            steps {
               sh 'dotnet test one.ut'
            }
        }
        stage('containerize') {
            agent any
            steps {
                script {
                   docker.build("one:${env.BUILD_NUMBER}","one") 
                }
            }
        }
        stage('system test') {
            agent any
            steps {
                script {
                    docker.image("one:${env.BUILD_NUMBER}").withRun('-p 80:80') { c ->
                        docker.image('microsoft/aspnetcore-build:2.0').inside("--link ${c.id}:app") {
                            sh 'curl http://localhost/api/values || echo not localhost'
                            sh 'curl http://localhost:5000/api/values || echo not localhost:5000'
                            sh 'curl http://app/api/values || echo not app'
                            sh 'curl http://app:5000/api/values || echo not app:5000'
                            sh 'baseurl=http://app; dotnet test one.st'
                        }
                    } 
                }
            }
        }
    }
}