pipeline {
    agent { docker 'microsoft/aspnetcore-build:2.0' }
    stages {
        stage('context') {
            steps {
                sh 'pwd;find .;ls ..;ls ../..'
                // sh 'ls ../*@script'
            }
        }
        stage('build') {
            steps {
               sh 'dotnet build' 
            }
        }
        stage('test') {
            steps {
               sh 'dotnet test one.test'
            }
        }
        // stage('Example') {
        //     steps {
        //         echo 'Hello World'

        //         script {
        //             def browsers = ['chrome', 'firefox']
        //             for (int i = 0; i < browsers.size(); ++i) {
        //                 echo "Testing the ${browsers[i]} browser"
        //             }
        //         }
        //     }
        // }
        stage('containerize') {
            steps {
                sh 'pwd'
                script {
                   def image = docker.build("one", "-t one:${env.BUILD_NUMBER} .") 
                }
            }
        }
    }
}