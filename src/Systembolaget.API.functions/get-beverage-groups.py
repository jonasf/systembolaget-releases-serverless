import os
import json
import boto3
from botocore.exceptions import ClientError


def get_groups(event, context):

    aws_region = os.environ['AWS_REGION']
    dynamodb = boto3.resource('dynamodb', region_name=aws_region)
    table = dynamodb.Table('SystembolagetReleases')
    groups = []
    try:
        response = table.scan()
    except ClientError as e:
        print(e.response['Error']['Message'])
    else:
        for item in response['Items']:
            if item['Group'] not in groups:
                groups.append(item['Group'])
    return {
        'data': json.dumps(groups)
    }
